    IReadOnlyList<IWebElement> attachments;
    public void RecursiveDeletion()
    {
        this.attachments = driver.FindElements(By.ClassName("attachment"));
        if (this.attachments.Count == 0) return;
        foreach (IWebElement attachment in this.attachments)
        {
            attachment.Click();
            driver.FindElement(By.ClassName("delete-attachment")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
        RecursiveDeletion();
    }
