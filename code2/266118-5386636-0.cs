    class Program
    {
        static void Main(string[] args)
        {
            A obj = new A();
            obj.SomeMethod();
            b ss = new b();
            ss.SomeMethod();
            Console.ReadLine();
        }
    }
    public interface ITest { void SomeMethod(); }
    class A : ITest { public void SomeMethod() {
        Console.WriteLine("SomeMethod Called from Class A object");
    } }
    class b : A
    {
        //public override void SomeMethod()
        //{
        //    Console.WriteLine("Called from Class B Object");
        //}
    }
