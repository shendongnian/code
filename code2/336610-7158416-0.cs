    //B class constructor
    public B(FireFox useThisInstance)
    {
      Span targetTab = useThisInstance.Span(Find.ByText("System")); //using instance created in A class
      targetTab.Click();
    }
