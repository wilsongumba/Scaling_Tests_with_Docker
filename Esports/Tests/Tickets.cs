﻿using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Base;

namespace League.Com.Tests
{
    [TestFixture]
    public class Tickets : TestBase
    {
        [Test]
        public void Goto_test()
        {
            Driver.Goto("https://google.com");
            Driver.FindElement(By.Name("q")).SendKeys("puppies");
            Driver.FindElement(By.Name("btnK")).Submit();
        }

        [Test]
        public void Cannot_buy_sold_out_tickets()
        {
            // 1. go to lolesports.com
            // 2. go to tickets page
            // 3. select first date
            // 4. validate you can't purchase
            //    - Add to Cart is disabled

            Esports.Goto();
            Esports.Tickets.Goto();
            Esports.Tickets.ClickFirstDate();
            Assert.IsTrue(Esports.Tickets.SoldOut());
        }
    }
}
