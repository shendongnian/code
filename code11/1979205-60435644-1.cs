    public abstract class Base
    {
        protected Base(string s)
        {
            // Do something with s? Remove if not needed!
        }
        // Make this abstract so it must be overridden by a derived class.
        protected abstract void ParseData(string s);
    }
    public class Derived : Base
    {
        public static Derived Create(string s)
        {
            var result = new Derived(s);
            result.ParseData(s);
            return result;
        }
        private Derived(string s) : base(s)  // Private to force use of Create().
        {
            // Whatever.
        }
        
        protected override void ParseData(string s)
        {
            Console.WriteLine(s + " Derived");
        }
    }
