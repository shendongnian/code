        static void Main(string[] args)
        {
        }
        static void Test(double arg)
        {
        }
        class Foo
        {
            private Action _field;
            public void InstanceMethod()
            {
                var capturedVariable = Math.Pow(42, 1);
                _field = () => Test(capturedVariable);  
            }
            private static void StaticMethod(double arg) { }
        }
    }
