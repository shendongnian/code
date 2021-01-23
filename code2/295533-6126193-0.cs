    public class SubClass : BaseClass
    {
        public static void DoSomething()
        {
        }
        public static void DoSomethingElse()
        {
            DoSomething(); // Calls SubClass
            BaseClass.DoSomething(); // Calls BaseClass
        }
    }
