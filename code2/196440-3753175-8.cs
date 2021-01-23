    public class MyClass
    {
      // a delegate by definition is a collection of pointers to method handlers
      // I declare my delegate on this line
      // PLEASE NOTE THE SIGNATURE!
      public delegate void MyFunctionDelegate(int some, string args);
      public MyClass() : base()
      {
        // instantiate the delegate (AKA create the pointer)
        MyFunctionDelegate myFunctionDelegate = new MyFunctionDelegate();
        // map a valid method handler (WITH THE SAME SIGNATURE) to this delegate
        // I'm using "+=" operator because you can add more than one handler to a collection
        myFunctionDelegate += new MyFunctionDelegate(PrintValues);
        // invoke the method handler (which in this case is PrintValues() - see below)
        // NOTE THE SIGNATURE OF THIS CALL
        myFunctionDelegate(1, "Test");
      }
      // this is the handler method that I am going to map to the delegate
      // AGAIN, PLEASE NOTE THE SIGNATURE
      public void PrintValues(int some, string args)
      {
        Console.WriteLine(string.Format("Some = {0} & Args = {1}", some.ToString(), args));
      }
    }
