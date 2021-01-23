    public class MyObjectViewModel 
    {
      private MyObject _object;
      
      public MyObjectViewModel(MyObject obj)
      {
        _object = obj;
      }
    
      public string Value1 
      { 
        get
        {
          return _object.Value1.ToString() //format for int
        }
      }
      
      public string Value2
      { 
        get
        {
          return _object.Value2.ToString() //format for double 
        }
      }
    
      public string Value3
      { 
        get
        {
          return _object.Value3
        }
      }
    }
