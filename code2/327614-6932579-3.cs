    public class Main
    {
        public enum FooEnum { A, B, C }
        public static void Main(string[] args)
        {
            // Note that since the method does not take an argument which
            // specifies the generic type, you must provide it explicitly.
            FooEnum randomFoo = EnumRandomizer.GetRandomValue<FooEnum>();
        }
    }
