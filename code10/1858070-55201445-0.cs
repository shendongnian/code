    public Dictionary<string,string> ListOfSections()
    {
        Dictionary<string,string> newDictionary = new Dictionary<string,string>();
        IList<IWebElement> tdSectionName = sectionTable.FindElements(By.XPath("//td[@class='name']"));
        foreach (IWebElement element in tdName)
        {
            IWebElement hierarchy = element.FindElement(By.XPath(".//span[@data-bind='text: hierarchyId']"));
            IWebElement name = element.FindElement(By.XPath(".//span[@data-bind='text: Name']"));
            newDictionary.Add(hierarchy.Text, name.Text);
        }
        return newDictionary;
    }
