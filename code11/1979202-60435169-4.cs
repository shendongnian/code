    public class Base
    {
        public Base(string s)
        {}
        protected virtual void ParseData(string s)
        {
            Console.WriteLine(s+ " Base");
        }
    }
    public class Derived : Base
    {
        public Derived(string s) : base(s){}
        protected override void ParseData(string s)
        {
            Console.WriteLine(s + " Derived");
        }
    }
