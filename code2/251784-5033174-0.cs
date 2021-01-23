    public class MyBase
    {
        public virtual void DoSomething() { Console.WriteLine("Base"); }
    }
    public class A : MyBase
    {
        public override void DoSomething() { Console.WriteLine("A"); }
    }
    public class B : MyBase
    {
        public override void DoSomething() { Console.WriteLine("B"); }
    }
