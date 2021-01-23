    // In SomeAssembly.dll
    public class TestClass
    {
        public static readonly int Field;
        
        static TestClass()
        {
            Field = 5;
        }
    }
    // In its own assembly
    public class Program
    {
        public static void Main()
        {
            BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.Public;
            Assembly someAssembly = Assembly.LoadFile(@"Path\To\SomeAssembly.dll");
            object field = someAssembly.GetType("TestClass")
                                       .GetField("Field", bindingFlags)
                                       .GetValue(null);
            Console.WriteLine(field);
        }
    }
