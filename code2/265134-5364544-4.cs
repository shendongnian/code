    class Program
    {
        static void SomeActionName(){}
        static void Main(string[] args)
        {
            LogMethodName(() => SomeActionName()); // <Main>b__0
            LogMethodName(SomeActionName); // SomeActionName
            var instance = new SomeClass();
            LogMethodName(() => instance.SomeClassMethod());; // <Main>b__1
            LogMethodName(instance.SomeClassMethod); // SomeClassMethod
        }
        private static void LogMethodName(Action action)
        {
            Console.WriteLine(action.Method.Name);
        }
    }
    class SomeClass
    {
        public void SomeClassMethod(){}
    }
