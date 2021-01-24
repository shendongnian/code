    interface IDoSomething
    {
      void DoSomething();
    }
    public class Thing1 : SomeBaseClass, IDoSomething
    {
        public void DoSomething(){ }
    }
    public class Thing2 : SomeBaseClass, IDoSomething
    {
        public void DoSomething() { }
    }
