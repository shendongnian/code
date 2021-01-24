    [Test]
    [AllureSeverity(SeverityLevel.critical)]
    public void CreateHierarchy()
    {
         AllureLifecycle.Instance.WrapInStep(() =>
         {
         // first step
         }, "first step");
         AllureLifecycle.Instance.WrapInStep(() =>
         {
            // second step
         }, "second step");
         AllureLifecycle.Instance.WrapInStep(() =>
         {
            // third step
         }, "third step");
    }
