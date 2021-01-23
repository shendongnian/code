    public static T call<T>(Func<T> fn)
    {
        // We will try to call the function up to 100 times...
        for (int i=0; i<100; ++i)
        {
            try
            {
                // We call the function passed in and return the result...
                return fn();
            }
            catch (COMException)
            {
                // We've caught a COM exception, which is most likely
                // a Server is Busy exception. So we sleep for a short
                // while, and then try again...
                Thread.Sleep(1);
            }
        }
        throw new Exception("'call' failed to call function after 100 tries.");
    }
