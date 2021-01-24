            IWebElement tableElement = driver.FindElement(By.XPath("//table[@id='skills-table']"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.XPath(".//a"));
            
            String[] rowTD = new String[tableRow.Count];
            int i = 0;
            foreach (IWebElement element in tableRow)
            {
                rowTD[i++] = element.Text;
                var URL = element.GetAttribute("href");
                Assert.ReferenceEquals(element.Text, URL);
             }
