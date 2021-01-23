    public class MyClass
    {
      private string _myString;
      public string MyString
      {
        get
        {
          return _myString;
        }
        private set
        {
          _myString = value;
        }
      }
    
      public MyClass(string myString)
      {
        // do some validation here
        _myString = myString;
      }
      // Not sure if you can change accessibility of constructor - I can try it later
      public MyClass()
      {}
    }
