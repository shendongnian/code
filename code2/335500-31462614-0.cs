         ConcurrentDictionary<string, int> TestDict = new ConcurrentDictionary<string,int>();
         [TestMethod]
         public void WorkingWithConcurrentDictionary()
         {
             //If Test doesn't exist in the dictionary it will be added with a value of 0
             TestDict.AddOrUpdate("Test", 0, (OldKey, OldValue) => OldValue+1);
             //This will increment the test key value by 1 
             TestDict.AddOrUpdate("Test", 0, (OldKey, OldValue) => OldValue+1);
             Assert.IsTrue(TestDict["Test"] == 1);
             //This will increment it again
             TestDict.AddOrUpdate("Test", 0, (OldKey, OldValue) => OldValue+1);
             Assert.IsTrue(TestDict["Test"] == 2);
             //This is a handy way of getting a value from the dictionary in a thread safe manner
             //It would set the Test key to 0 if it didn't already exist in the dictionary
             Assert.IsTrue(TestDict.GetOrAdd("Test", 0) == 2);
             
             //This will decriment the Test Key by one
             TestDict.AddOrUpdate("Test", 0, (OldKey, OldValue) => OldValue-1);
             Assert.IsTrue(TestDict["Test"] == 1);
         }
