    [TestMethod]
    public void TestMethod1()
    {
      List<ValueChain> values = new List<ValueChain>(new [] 
                                {
                                  new ValueChain("d10a9"),
                                  new ValueChain("d10a10")
                                });
      ValueChain max = 
        values.OrderByDescending(v => v, new ValueChainComparer()).FirstOrDefault();
    }
