    public class Example
    {
        private interface ITest
        {
            int TestFunc();
            int TestFunc2(string value);
        }
    
        public static void Main()
        {
            ITest t = null;
            DoWork(t.TestFunc);
            DoWork2(t.TestFunc2);
        }
    
        public static void DoWork<TResult>(Func<TResult> func)
        {
        }
    
        public static void DoWork2<TResult>(Func<string, TResult> func)
        {
        }
    }
