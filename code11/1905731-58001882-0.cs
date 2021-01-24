    [SkippableTheory]
    [MemberData(nameof(SomeTestData)]
    public void MyTheory(object someData)
    {
      skip.IfNot(dotMemoryApi.IsEnabled);
     
      // otherwise, proceed with dotMemory unit test calls 
      .
      .
      .
