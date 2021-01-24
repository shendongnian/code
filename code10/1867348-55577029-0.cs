    class Program
    {
        static void Main(string[] args)
        {
            A thing1 = new A();
            B thing2 = new B();
            B thing3 = new B();
            List<IBase> list = new List<IBase> { thing1, thing2, thing3 };
            foreach (IBase bas in list) {
                Console.WriteLine(bas.Stringify());
            }
        }
    }
    public interface IBase
    {
        string Stringify();
    }
    public class Base : IBase
    {
        public string Stringify() { return "I am a member of base class"; }
    }
    public class A : Base
    {
        public void DoAThing()
        {
        }
    }
    public class B : Base
    {
        public void DoBThing(int anInteger)
        {
        }
    }
