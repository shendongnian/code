    class Program
    {
        static void Main(string[] args)
        {
        }
        class Foo
        {
            private Action _field;
            public void InstanceMethod()
            {
                var capturedVariable = Math.Pow(42, 1);
                _field = () => Foo2.StaticMethod(capturedVariable);  //Foo2
            }
            private static void StaticMethod(double arg) { }
        }
        class Foo2
        {
            internal static void StaticMethod(double arg) { }
        }
    }
