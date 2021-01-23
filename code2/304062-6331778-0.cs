    public string[] TestResults;
    public MyClass()
    {
        TestResults = new string[8];
    }
    public string TestName
    {
        get { return TestResults[0]; }
        set { TestResults[0] = value; }
    }
