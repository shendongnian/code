    [ClassInitialize()]
    public void CLassInitialization(TestContext context)
    {
        path = Path.Combine(Environment.CurrentDirectory, @"Folder\", "Customer.json");
    }
