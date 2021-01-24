    public double ReturnDevID()
    {
         var rnd = new Random();
         return rnd.NextDouble();
    }
    public void TestRandom()
    {
         // Call the method 100 times and save the result in a list
         var randoms = Enumerable.Range(0, 100)
                                 .Select(i => ReturnDevID())
                                 .ToList();
          // Make sure you have no duplicates
          Assert.AreEqual(randoms.Count, randoms.Distinct().Count());
    }
