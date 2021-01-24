    static class CancellationTokenExtensions
    {
        public static Task AsTask(this CancellationToken token)
        {
            return new Task(() => throw new InvalidOperationException(), token);
        }
    }
