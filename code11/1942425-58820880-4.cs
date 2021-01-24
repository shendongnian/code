        private void ClickRandomLinks(string linkText = null)
        {
            //get all links
            var links = _driver.FindElements(By.TagName("a")).ToList();
            //click all links matching predicate
            if (!string.IsNullOrEmpty(linkText))
            {
                var linkElements = links.Where(x => x.GetAttribute("href").Contains(linkText)).ToList();
                if(!linkElements.Any()) throw new Exception($"Links with name: {linkText} not found");
                //Generate random order
                var randomElements = Enumerable.Range(0, linkElements.Count-1).OrderBy(x => Guid.NewGuid()).ToList();
                randomElements.ForEach(x => linkElements.ElementAt(x).Click());
            }
            else
            {
                //click all links randomnly
                var randomElements = Enumerable.Range(0, links.Count-1).OrderBy(x => Guid.NewGuid()).ToList();
                randomElements.ForEach(x => links.ElementAt(x).Click());                
            }
        }
