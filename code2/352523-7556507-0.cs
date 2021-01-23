        static void Main(string[] args)
        {
            //Get method Method[T]
            var method = typeof(Program).GetMethod("Method", BindingFlags.NonPublic | BindingFlags.Static);
            //Create generic method with given type (here - int, but you could use any time that you would have at runtime, not only at compile time)
            var genericMethod = method.MakeGenericMethod(typeof(int));
            //Invoke the method
            genericMethod.Invoke(null, null);
        }
        static void Method<T>()
        {
            Console.WriteLine(typeof(T).Name);
        }
