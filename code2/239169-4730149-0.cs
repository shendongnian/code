    public class Parent<T> 
        where T : Parent<T>, new
    {
        public static T Create()
        {
            return new T(); // would be typically something more sophisticated
        }
    }
    public class Child : Parent<Child>
    {
    }
