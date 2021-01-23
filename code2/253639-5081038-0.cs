    public class TestClass
    {
        public static readonly int Field;
        
        static TestClass()
        {
            Field = 5;
        }
    }
    public class Program
    {
        public static void Main()
        {
            object field = typeof(TestClass).GetField("Field", BindingFlags.Static | BindingFlags.Public).GetValue(null);
            Console.WriteLine(field);
        }
    }
