    public void Test()
    {
        IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3.00));
        SelectElement Select = new SelectElement(_driver.FindElement(By.Id("ListBox")));
        if (!Select.Options.Where(e => e.Text == "TEST").Any())
        {
            _driver.FindElement(By.Id("AddButton")).Click();
            var newRecordInfo = table.CreateSet<FeatureInfo>();
            foreach (var recordData in newRecordInfo)
            {
                _driver.FindElement(By.Id("DescTextBox")).SendKeys(recordData._discription);
                _driver.FindElement(By.Id("PaTextBox")).SendKeys(recordData._score);
                new SelectElement(_driver.FindElement(By.Id("DropDown"))).SelectByValue("1");
                _driver.FindElement(By.Id("SaveButton")).Click();
            }
        }
        else
        {
            Select.SelectByText("TEST");
            _driver.FindElement(By.Id("DeleteButton")).Click();
            _driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
        }
    }
