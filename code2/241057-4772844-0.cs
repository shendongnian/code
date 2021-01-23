    class Program
    {
        public Program() { Console.WriteLine(this); }
        static void Main(string[] args)
        {
            other p = new other();
            Console.WriteLine(p);
            Console.ReadLine();
        }
    }
    class other : Program
    {
        string s1 = "Hello";
        string s2;
        public other() { s2 = "World"; }
        public override string ToString() { return s1 + s2; }
    }
