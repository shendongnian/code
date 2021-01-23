    public interface IMyFoo1 { void DoSomething(string instance); }
    public interface IMyFoo2 { void DoSomething(string instance); }
    public interface IMyBar : IMyFoo1, IMyFoo2 { }
    public class MyTestClass : IMyBar
    {
        //Explicit interface declaration required
        void IMyFoo1.DoSomething(string instance) { }
        void IMyFoo2.DoSomething(string instance) { }
    }
    string s = "";
    IMyBar bar = new MyTestClass();
    bar.DoSomething(s);//The call is ambiguous between the following methods or properties...
