    public class MyBase
    {
        public string UserName {get;set;}
    }
    public class MyClass : MyBase
    {
      public void DoSomething()
      {
         Console.WriteLine("UserName: {0}", UserName);
      }
    }
