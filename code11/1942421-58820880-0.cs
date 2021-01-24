        private void ClickRandomLink(string linkText = null)
        {
           //get all links
            var links = _driver.FindElements(By.TagName("a")).ToList();
            if (!string.IsNullOrEmpty(linkText))
            {
                var link = links.FirstOrDefault(x => x.GetAttribute("href").Equals(linkText)) ??
                           throw new Exception($"Link with name: {linkText} not found");
                link.Click();
            }
            else
            {
                //click random element in list
                links.ElementAt(new Random().Next(0, links.Count - 1)).Click();
            }
         }
