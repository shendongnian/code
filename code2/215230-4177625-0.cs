    public class MyClass
    {
      private Dictionary<string, string> myDictionary;
      
      public string this[string key]
      {
        get { return myDictionary[key]; }
      }
    }
