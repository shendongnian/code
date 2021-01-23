    // Assert that each item name is fewer than 8 characters.
    [TestMethod]
    public void Test()
    {
       List<string> failures = new List<string>();
       // However you get your list in the first place
       List<Item> itemsToTest = GetItems(); 
    
       foreach (Item item in itemsToTest )
       {
          // if fail, continue on with the rest
          if (item.Name.Length > 8 )
          {
             failures.Add(item.Name);
          }
       }
    
       foreach (string failure in failures)
       {
          Console.WriteLine(failure);
       }
    
       Assert.AreEqual(0, failures.Count);
    }
