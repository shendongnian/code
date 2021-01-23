            private void WaitUntilExistsThenClick(string selectorId)
        {
            var searchBoxExists = new State(() => browser.FindId(selectorId).Exists());
            if (browser.FindState(searchBoxExists) == searchBoxExists)
            {                
                browser.FindId(selectorId).Click();
            }
        }       
