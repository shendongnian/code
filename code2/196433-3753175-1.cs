    public class MyDelegateClass
    {
      public delegate int MyFunctionDelegate(int some, string args);
      private int _some = 0;
      private string _args = "";
      public MyDelegateClass() : base() { }
      public void SomeFunction(MyFunctionDelegate myFunction)
      {
        myFunction(_some, _args);
      }
      public int Some
      {
        get { return _some; }
        set { _some = value; }
      }
		
      public void Args
      {
        get { return _args; }
        set { _args = value; }
      }
    }
    class Program
    {
      static void PrintValues(int some, string args)
      {
        Console.WriteLine(string.Format("Some = {0} & Args = {1}", some.ToString(), args));
      }
      static void Main(string[] args)
      {
        MyDelegateClass myDelegateClass = new MyDelegateClass();
        myDelegateClass.Some = 1;
        myDelegateClass.Args = "Testing";
        myDelegateClass.SomeFunction(new MyFunctionDelegate(PrintValues))
      }
    }
