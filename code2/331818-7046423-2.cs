    [TestMethod]
    public void TestMethod1()
    {
        int i = 10;
    
        while(i-- > 0)
        {
            Thread.Sleep(1000);
            Debug.WriteLine("Step #" + i);
        }
    }
