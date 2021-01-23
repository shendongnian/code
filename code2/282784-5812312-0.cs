    public interface I { void F(); }
    public struct C : I {
        public int i;
        public void F() { i++; } 
        public int GetI() { return i; }
    }
    
        class P
        {
        static void Main(string[] args)
        {
            C x = new C();
            I ix = (I)x;
            ix.F();
            ix.F();
            x.F();
            ((I)x).F();
            Console.WriteLine(x.GetI());
            Console.WriteLine(((C)ix).GetI());
            Console.ReadLine();
        }
    }
