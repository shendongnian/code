    public void SelectName(string name)
    {
        foreach (IWebElement element in NamesList)
        {
            if (element.Text.Equals(name))
            {
                element.Click();
                break;
            }
        }
    }    
