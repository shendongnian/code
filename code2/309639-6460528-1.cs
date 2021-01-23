        [TestMethod]
        public void TestPagingCauseFailure()
        {
            // act
            OpenPage(true);
            // get the hidden fields on this page
            IList<HtmlInputHidden> _hiddenFieldsList = Find.AllByAttributes<HtmlInputHidden>("~hfFailureID");
            
            IList<HtmlAnchor> _pageIndexes = Find.AllByAttributes<HtmlAnchor>("href=~pageid");
            // there are 12 pages (not including page 1)
            Assert.IsTrue(Equals(12,_pageIndexes.Count));
            // goto last page
            _pageIndexes.Last().Click();
            //get the hidden fields on this page
            IList<HtmlInputHidden> _hiddenFieldsList2 = Find.AllByAttributes<HtmlInputHidden>("~hfFailureID");
            string value1 = _hiddenFieldsList.Last().ID;
            string value2 = _hiddenFieldsList2.Last().ID;
            
            //compare the two last items in boths lists
            Assert.IsFalse(Equals(value1, value2));
        }
