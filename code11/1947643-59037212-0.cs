    //Test:
    [TestMethod]
            public void FindElementInCounterTest()
            {
                _driver.Navigate()
                    .GoToUrl("https://localhost:5001/counter");
    
                WaitXseconds(10000); // wait 10 secs
    
                var res = _driver.FindElement(By.Id("counter100"));
                var res2 = _driver.FindElement(By.TagName("h1"));
                var res3 = _driver.FindElement(By.TagName("title"));
                Assert.AreEqual(true, res.Displayed);
                Assert.AreEqual("Counter", res.Text);
                Assert.AreEqual(true, res2.Displayed);
                Assert.AreEqual("Counter", res2.Text);
                Assert.AreEqual(false, res3.Displayed);
                Assert.AreEqual("", res3.Text);//Assert.AreEqual("This is a title.", res3.Text);
    
                //.SendKeys("");
    
                Assert.AreEqual(false, string.IsNullOrEmpty(_driver.Title));
                Assert.AreEqual(false, string.IsNullOrEmpty(_driver.PageSource));
            }
