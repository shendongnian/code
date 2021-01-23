        private static void Method1(Type type)
        {
            MethodInfo methodInfo = typeof(Program).GetMethod("Method2", BindingFlags.NonPublic | BindingFlags.Static);
            MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(type);
            genericMethodInfo.Invoke(null, null);
        }
        private static void Method2<T>()
        {
            Console.WriteLine(typeof(T).FullName);
        }
