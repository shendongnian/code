    public class Base
    {
        // Base method has a 'class' constraint
        public virtual List<T> MyMethod<T>() where T : class
        {
            return new List<T>();
        }
    }
    public class Derived : Base
    {
        // Override does not declare any constraints; constraints are inherited
        public override List<T> MyMethod<T>()
        {
            // base call works just fine
            return base.MyMethod<T>();
        }
    }
