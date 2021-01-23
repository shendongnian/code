    class A
    {
        public virtual void DoSomething() { Console.WriteLine("From A"); }
    }
    class B : A
    {
        public override void DoSomething() { Console.WriteLine("From B"); }
    }
    class C
    {
        public void DoSomethingMagic(A someClassInstance)
        {
            someClassInstance.DoSomething();
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            c.DoSomethingMagic(a); // Prints "From A"
            c.DoSomethingMagic(b); // Prints "From B", even though it takes an A
            A bIsAnA = new B();
            c.DoSomethingMagic(bIsAnA); // Prints "From B", because B is also an A
        }
    }
