    public class MyCustomType
    {
        public static int NumFinalizersCalled;
    
        ~MyCustomType()
        {
            Interlocked.Increment(ref NumFinalizersCalled);
        }
    }
