    for (int index = 0; index < exports.Rows.Count; index++)
            {
                var reportListBox = driver.FindElement(By.ClassName("rlbList"));
                IWebElement reportItem = reportListBox.FindElement(By.CssSelector($"#ctl00_ContentPlaceHolder_lstReports_i{index}"));
                
                reportItem.Click();
                exportBTNClick();
                IWebElement modal = driver.FindElement(By.XPath("//span[@class='rwInnerSpan'][contains(text(),'OK')]"));                  
                if (modal.Displayed == true)
                {
                   
                    // If Error Message appears then Click ok
                    driver.FindElement(By.XPath("//span[@class='rwInnerSpan'][contains(text(),'OK')]")).Click();
                    
                    driver.FindElement(By.XPath("//span[@class='rwInnerSpan'][contains(text(),'OK')]")).Click();
                    
                }
               
            }
