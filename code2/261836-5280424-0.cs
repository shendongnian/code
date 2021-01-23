    class MyClass
    {
    
      public int x {get;set;}
      MyClass()
      {
          x = 3;
      }
    
      void Foo()
      {
          Type type = GetType();
          PropertyInfo pInfo = type.GetProperty("x");
     
          object xValue= pInfo.GetValue(this, null);
          Console.Writeln(xValue); 
      }
    
    
    }
