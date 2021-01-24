    List<WebElement> LinkElements = driver.FindElements(By.Id(“element id”));
    List<string> ValidLinks = new List<string>();  
    foreach(WebElement LinkElement in LinkElements){
      string LinkString = LinkElement.GetAttribute("href");
      if(Equals("abc.com", LinkString.SubString(0, 7))){
        ValidLinks.Add(LinkString);
        }
    }
    
    CollectionAssert.AreEquivalent(Links.Count, ValidLink.Count);
    Random r = new Random();
    LinksElements[r.Next(0,LinksElements.Count)].Click();
