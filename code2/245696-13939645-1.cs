    [TestMethod]
    public void TestMethod1()
    {
        Debug.WriteLine("Time {0}", DateTime.Now);
        System.Threading.Thread.Sleep(30000);
        Debug.WriteLine("Time {0}", DateTime.Now);
    }
