    // Test object definition
    class TestClass
    {
      public TestClass()
      {
        this.TheNestedList = new List<List<double>>() {new List<double>() {1, 2, 3, 4}, new List<double>() {11, 22, 33, 44}};
      }
    
      public List<List<double>> TheNestedList { get; set; }
    }
    // Usage example
    static void Main(string[] args)
    {
      var testClass = new TestClass();
      // Convert testClass instance to Dictionary<string, object>
      Dictionary<string, object> testClassDictionary = testClass.ToDictionary();
      // Consume the result and 
      // retrieve the outer List<List<double>>
      var nestedListProperty = testClassDictionary["NestedList"] as Dictionary<string, object>;
      if ((bool) nestedListProperty["IsCollection"])
      {
        // Retrieve the inner List<double>
        for (var index = 0; index < (int) theNestedListProperty["Count"]; index++)
        {
          var itemOfOuterList = theNestedListProperty[index.ToString()] as Dictionary<string, object>;
          if ((bool) itemOfOuterList["IsCollection"])
          {
            // Retrieve the double values
            for (var nestedListIndex = 0; nestedListIndex < (int) itemOfOuterList["Count"]; nestedListIndex++)
            {
              var innerListValue = (double) itemOfOuterList[nestedListIndex.ToString()];
            }
          }
        }
      }
    }
