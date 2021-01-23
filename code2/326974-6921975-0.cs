    public static class ProcessWindowsMessagesExtension
    {
        public static ParallelQuery<TSource> DoEvents<TSource>(this ParallelQuery<TSource> source)
        {
            return source.Select(
                item =>
                {
                    Application.DoEvents();
                    Thread.Yield();
                    return item;
                });
        }
    }
