    IWebElement mainForm = null;
    IReadOnlyCollection<IWebElement> forms = Driver.FindElements(By.CssSelector("form"));
    int maxCount = 0;
    foreach (IWebElement form in forms)
    {
        int count = form.FindElements(By.CssSelector("input:not([type='hidden'])")).Count;
        if (count > maxCount)
        {
            maxCount = count;
            mainForm = form;
        }
    }
    // do something with mainForm
    Console.WriteLine(mainForm?.GetAttribute("name"));
