    public void SelectName(string name)
    {
        foreach (IWebElement element in NamesList)
        {
            if (element.Text.Equals(name))
            {
                element.Click();
                return;
            }
        }
        throw new Exception("No elements with text " + name + " were found");
    }    
