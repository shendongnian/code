    public class SomeClass
    {
        public void Method()
        {
            ExtensionMethod();
        }
    }
    public static class Extensions
    {
        public static void ExtensionMethod(this SomeClass sc) { }
    }
