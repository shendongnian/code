    List<WebElement> LinkElements = new List<WebElement>();  
    LinkElements = driver.FindElement(By.Id(“element id”));
    List<string> ValidLinks = new List<string>();  
    foreach(var LinkElement in LinkElements){
      string LinkString = LinkElement.GetAttribute("href");
      if(Equals("abc.com", LinkString.SubString(0, 7))){
        ValidLinks.Add(LinkString);
        }
    }
    
    CollectionAssert.AreEquivalent(Links.Count, ValidLink.Count);
    Random r = new Random();
    LinksElements[r.Next(0,LinksElements.Count)].Click();
