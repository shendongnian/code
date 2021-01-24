    [ClassInitialize()]
    public static void CLassInitialization(TestContext context)
    {
        path = Path.Combine(Environment.CurrentDirectory, @"Folder\", "Customer.json");
    }
