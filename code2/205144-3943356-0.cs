    public class Base<T>
    {
        public static T Create(byte[] data)
        {
            // create instance of T from data
        }
    }
    public Derived1 : Base<Derived1>
    {
    }
    public Derived2 : Base<Derived2>
    {
    }
