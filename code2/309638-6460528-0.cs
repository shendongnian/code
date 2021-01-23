    [TestMethod]
            public void TestPagingCauseFailure()
            {
                // act
                OpenPage(true);
    
                // get the hidden fields on this page
                var _hiddenFieldsList = ActiveBrowser.Find.ById<HtmlInputHidden>("~hfFailureID");
                
                IList<HtmlAnchor> _pageIndexes = Find.AllByAttributes<HtmlAnchor>("href=~pageid");
    
                // there are 12 pages (not including page 1)
                Assert.IsTrue(Equals(12,_pageIndexes.Count));
    
                // goto last page
                _pageIndexes.Last().Click();
    
                //get the hidden fields on this page
                var _hiddenFieldsList2 = ActiveBrowser.Find.ById<HtmlInputHidden>("~hfFailureID");
    
                //compare the two first items in the list
                Assert.IsFalse(Equals(_hiddenFieldsList,_hiddenFieldsList2));
    
            }
