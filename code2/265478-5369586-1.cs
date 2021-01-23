    [TestMethod()]
    void MyTest_4_Times()
    {
        var n = 4;
        Task.WaitAll(Enumerable.Range(0, n).Select(_ => Task.Factory.StartNew(MyTest)).ToArray());
    }
