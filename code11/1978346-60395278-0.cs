    IReadOnlyCollection<IWebElement> chatRow = driver.FindElements(By.XPath("//*[@data-tid='message']/div"));
    for (int i = 0; i < chatRow.Count; i++)
    {
        chatRow.ElementAt(i).GetAttribute("innerHTML");
    }
