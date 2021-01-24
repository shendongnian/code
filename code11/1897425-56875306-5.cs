        public void SetMaritalStatus(string value)
        {
            _driver.FindElement(By.Id("mainApplicant.maritalStatus")).Click();
            _driver.FindElement(By.XPath(string.Format("//ul[@class='dropdown-menu show']//li[@role='presentation']//a[@class='dropdown-item']/option[text()='{0}']", value))).Click();
        }
