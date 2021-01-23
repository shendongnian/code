    public void Test()
    {
        IMFDBAnalyserPlugin myClass = new PrimaryKeyChecker();
        var result = myClass.RunAnalysis("you connection string");
    }
