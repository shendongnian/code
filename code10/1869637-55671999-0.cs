    [OneTimeSetUp]
    public void Init()
    {
       Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
    }
