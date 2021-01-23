    public class Base
    {
        public Base()
        {
            Dump();
        }
        public virtual void Dump() {}
    }
    public class Child
    {
        private string x = "Initialized at declaration";
        private string y;
        public Child()
        {
            y = "Initialized in constructor";
        }
        public override void Dump()
        {
            Console.WriteLine(x); // Prints "Initialized at declaration"
            Console.WriteLine(y); // Prints "" as y is still null
        }
    }
