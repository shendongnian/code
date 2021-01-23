    public class Base<T> where T : new()
    {
        public static T Instance
        {
            get { return new T(); }
        }
    }
    public class Derived : Base<Derived>
    {
    }
