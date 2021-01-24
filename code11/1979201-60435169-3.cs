    public class Derived : Base
    {
        public Derived(string s) : base(s){}
        internal new void ParseData(string s)
        {
            Console.WriteLine(s + " Derived");
        }
    }
