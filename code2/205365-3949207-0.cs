    public abstract class Base
    {
    }
    public class Base<T> : Base where T : class
    {
        public static T Create()
        {
            // create T somehow
        }
    }
    public class Derived1 : Base<Derived1>    // also inherits non-generic Base type
    {
    }
    public class Derived2 : Base<Derived2>    // also inherits non-generic Base type
    {
    }
