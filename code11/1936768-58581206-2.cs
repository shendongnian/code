    public interface IA
    {
        void DoA();
    }
    public interface IB : IA
    {
        void DoB();
    }
    public class B : IB, IA
    {
        public void DoA() { Console.WriteLine("DoA in B."); }
        public void DoB() { Console.WriteLine("DoB in B."); }
    }
    public class C : B, IA
    {
        void IA.DoA() { Console.WriteLine("DoA in C."); }
    }
