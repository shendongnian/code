    public class Base 
    {
        public static T Create<T>() where T : class
        {
            return Activator.CreateInstance<T>();
        }
    }
    public class Derived1 : Base
    {
    }
    public class Derived2 : Base
    {
    }
