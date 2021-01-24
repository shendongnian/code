     [TestMethod]
            public void ListBoxTest()
            {
                //lbStates
                var lbStates = sessionWinForm.FindElementByAccessibilityId("lbStates");
                var allListItems = lbStates.FindElementsByTagName("ListItem");
                var valueToClick = "NC";
                var maxClicks = 10;
                foreach(var ali in allListItems)
                {
                    Debug.WriteLine($"{ali.Displayed} - {ali.Text}");
                    if(ali.Text.Equals(valueToClick) && !ali.Displayed)
                    {
                        var downButton = lbStates.FindElementByAccessibilityId("DownButton");
                        var listItemToClick = lbStates.FindElementByName(valueToClick);
     
                        while(!listItemToClick.Displayed && (maxClicks-- > 0))
                        {
                            downButton.Click();
                            listItemToClick = lbStates.FindElementByName(valueToClick);
     
                            if (listItemToClick.Displayed)
                            {
                                listItemToClick.Click();
                            }
                        }
                    }
                }
            }
