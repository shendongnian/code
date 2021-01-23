    abstract class Foo
    {
        public abstract void Set(string value);
    }
    
    class FooDouble : Foo
    {
        double val;
        public override void Set(string value)
        {
            this.val = double.Parse(value);
        }
    }
    
    // Etc.
