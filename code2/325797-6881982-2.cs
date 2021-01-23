    private StringBuilder testFailed;
    public void Test1()
    {
        testFailed = new StringBuilder();
        testFailed.AppendLine(SomeTest());
    }
    public void Test2()
    { 
        testFailed = new StringBuilder();
        testFailed.AppendLine(someTest1());
    }
