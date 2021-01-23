    public class MyClass
    {
      // a delegate by definition is a collection of pointers to handlers
      // I define my delegate on this line (please note the signature)
      public delegate void MyFunctionDelegate(int some, string args);
      public MyClass() : base()
      {
        // instantiate the delegate (AKA create the pointer)
        MyFunctionDelegate myFunctionDelegate = new MyFunctionDelegate();
        // map a valid handler (with the same signature) to this delegate
        // I'm using "+=" operator because you can add more than one handler to a collection
        myFunctionDelegate += new MyFunctionDelegate(PrintValues);
        // invoke the handler method (which in this case is PrintValues() - see below)
        myFunctionDelegate(1, "Test");
      }
      // this is the handler method that I am going to map to the delegate (please note the signature)
      public void PrintValues(int some, string args)
      {
        Console.WriteLine(string.Format("Some = {0} & Args = {1}", some.ToString(), args));
      }
    }
