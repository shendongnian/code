    [TestMethod()]
    void MyTest()
    {
        // Do Something
    }
    
    [TestMethod()]
    void MyTest_4_Times()
    {
        Parallel.Invoke(MyTest, MyTest, MyTest, MyTest);
    }
