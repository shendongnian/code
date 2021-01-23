        public static class DelegateExtensions
    {
        public static void SafeInvoke(this Delegate del,params object[] args)
        {
            foreach (var handler in del.GetInvocationList())
            {
                try
                {
                        handler.Method.Invoke(handler.Target, args);
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
        }
    }
