    public static class UnityContainerExtensions
    {
        public static void TryAllImplementations<TService>(
            this IUnityContainer container,
            Action<TService> operation,
            Action<Exception> exceptionHandler = null)
        {
            int dummy = 0;
            container.TryAllImplementations<TService, int>(
                svc => { operation(svc); return dummy; },
                exceptionHandler);
        }
        public static TReturn TryAllImplementations<TService, TReturn>(
            this IUnityContainer container,
            Func<TService, TReturn> operation,
            Action<Exception> exceptionHandler = null)
        {
            foreach (var svc in container.ResolveAll<TService>())
            {
                try
                {
                    return operation(svc);
                }
                catch (Exception ex)
                {
                    if (exceptionHandler != null)
                        exceptionHandler(ex);
                }
            }
            throw new ProgramException("All implementations have failed.");
        }
    }
