    interface ISomeData
    {
      IEnumerable<string> YourData {get;}
    }
    
    class SomeData
    {
      // This class is a singleton that could read
      // all apropriate data from application configuration file into SomeData
      // instance and then return this instance in following property
      public static ISomeData {get;}
    }
    
    class YourClass
    {
      private readonly ISomeData _someData;
    
      public YourClass(ISomeData someData)
      {
        _someData = someData;
      }
    
      // You can even create additional parameterless constructor that will use
      // your singleton
      pbulic YourClass()
        : this(SomeData.Instance)
      {}
    }
