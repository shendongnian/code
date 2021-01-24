    public class MyX
    {
      public int MyValue;
    }
    
    public class MyY
    {
      public int MyValue;
    
      public void SomeMethod()
      {
        MyValue = 42; // MyValue is in scope here, since it's a member of `MyY`,
                      // and we're in an instance method on `MyY`
        var myX = new MyX();
        myX.MyValue = 50; // MyValue must be qualified with an instance
    
        var myY = new MyY();
        myY.MyValue = 60; // MyValue must be qualified, otherwise `this` is implied
        var myself = this;
        Console.WriteLine(myself.MyValue); // Prints 42
      }
    }
