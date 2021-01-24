    public static class SilentRunner
    {
        public static void Run(Action action, Action<Exception> onErrorHandler)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                onErrorHandler(e);
            }
        }
        public static T Run<T>(Func<T> func, Action<Exception> onErrorHandler)
        {
            try
            {
                return func();
            }
            catch (Exception e)
            {
                onErrorHandler(e);
            }
            return default(T);
        }
    }
