    public class MyObject
    {
      private SomeOtherObject _dependentObject;
    
      [Dependency]
      public SomeOtherObject DependentObject 
      {
        get { return _dependentObject; }
        set { _dependentObject = value; }
      }
    }
