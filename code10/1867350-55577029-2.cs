    class Program
    {
        static void Main(string[] args)
        {
            A thing1 = new A();
            B thing2 = new B();
            B thing3 = new B();
            List<Base> list = new List<Base> { thing1, thing2, thing3 };
            foreach (Base bas in list) {
                Console.WriteLine(bas.Stringify());
                if(bas is A)
                {
                    ((A)bas).DoAThing();
                }
                else if (bas is B)
                {
                    ((B)bas).DoBThing(1);
                }
                else
                {
                    //IDK
                }
            }
        }
    }
    public abstract class Base
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
