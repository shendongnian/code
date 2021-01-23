    [TestMethod()]
    public void DoSomethingTest()
    {
        int n = 10; // changed to 10, see comment
        Parallel.For(0, n, i =>  DoSomething());
        // here all threads are completed 
    }
