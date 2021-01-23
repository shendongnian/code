    [TestMethod]
    public void Test()
    {
       List<string> failures = new List<string>();
    
       foreach (item in list)
       {
          // if fail, continue on with the rest
          if (fail(item))
          {
             failures.Add(item.name);
          }
       }
    
       foreach (string failure in failures)
       {
          Console.WriteLine(failure);
       }
    
       Assert.AreEqual(0, failures.Count);
    }
