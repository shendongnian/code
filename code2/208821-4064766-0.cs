    public class AsyncTestHelper
    {
        public delegate bool TestDelegate();
        public static bool AssertOrTimeout(TestDelegate predicate, TimeSpan timeout)
        {
            var start = DateTime.Now;
            var now = DateTime.Now;
            bool result = false;
            while (!result && (now - start) <= timeout)
            {
                Thread.Sleep(50);
                now = DateTime.Now;
                result = predicate.Invoke();
            }
            return result;
        }
    }
