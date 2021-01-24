    internal static class MyClassShared
    {
        public static string Shared;
    }
    public class MyClass<T>
    {
        public void Set(string value)
        {
            MyClassShared.Shared = value;
        }
    
        public void Get()
        {
            Console.WriteLine(MyClassShared.Shared);
        }
    }
