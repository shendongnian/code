    IWebElement element = _browserInstance.Driver.FindElement(By.XPath("//Select"));
    IList<IWebElement> AllDropDownList = element.FindElements(By.XPath("//option"));
    int DpListCount = AllDropDownList.Count;
    for (int i = 0; i < DpListCount; i++)
    {
        if (AllDropDownList[i].Text == "nnnnnnnnnnn")
        {
            AllDropDownList[i].Click();
            _browserInstance.ScreenCapture("nnnnnnnnnnnnnnnnnnnnnn");
        }
    }
