    [ClassInitialize]
    public static void MyClassInitialize(TestContext testContext)
    {
        GlobalBackend.EnsureStarted();
    } 
