    class CallOverride
    {
        public static void Test()
        {
            var obj = new Override();
            var method = typeof(object).GetMethod("ToString");
            var ftn = method.MethodHandle.GetFunctionPointer();
            var func = (Func<string>)Activator.CreateInstance(typeof(Func<string>), obj, ftn);
            Console.WriteLine(func());
        }
    }
    class Override
    {
        public override string ToString()
        {
            return "Nope";
        }
    }
