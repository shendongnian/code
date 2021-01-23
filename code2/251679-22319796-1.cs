    [Given(@"I have entered '(.*)' into the commentbox")]
    public void GivenIHaveEnteredIntoTheCommentbox(string p0)
    {
                Browser.Current.FindElement(By.Id("comments")).SendKeys(p0);
    }
