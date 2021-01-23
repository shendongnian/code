        static void TestIConvertible()
        {
            string test = "test";
            Type stringType = test.GetType();
            bool isConvertibleDirect = test is IConvertible;
            bool isConvertibleTypeAssignable = stringType.IsAssignableFrom(typeof(IConvertible));
            bool isConvertibleHasInterface = stringType.GetInterface(nameof(IConvertible)) != null;
            Console.WriteLine($"isConvertibleDirect: {isConvertibleDirect}");
            Console.WriteLine($"isConvertibleTypeAssignable: {isConvertibleTypeAssignable}");
            Console.WriteLine($"isConvertibleHasInterface: {isConvertibleHasInterface}");
        }
