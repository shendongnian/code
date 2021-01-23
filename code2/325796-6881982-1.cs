    Private StringBuilder testFailed;
    Public void Test1()
    {
    testFailed=new StringBuilder();
    testFailed.AppendLine(SomeTest());
    }
    Public void Test2()
    { 
    testFailed=new StringBuilder();
    testFailed.AppendLine(someTest1());
    }
