    public class A
    {
        public void DoSomething(){ Console.WriteLine("42!"); }
    }
    public class B : A
    {
        public virtual new void DoSomething(){ Console.WriteLine("Not 42!"); }
    }
    public class C : B
    {
        public override void DoSomething(){ Console.WriteLine("43!"); }
    }
