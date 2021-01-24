    public static class Async
    {
        private static readonly TaskCompletionSource<bool> _neverComplete = new TaskCompletionSource<bool>();
        public static Task CompleteOnCancellation( CancellationToken token )
        {
            if ( !token.CanBeCanceled )
                return _neverComplete.Task;
            if ( token.IsCancellationRequested )
                return Task.CompletedTask;
            var tcs = new TaskCompletionSource<bool>();
            token.Register( () => tcs.SetResult( true ) );
            return tcs.Task;
        }
    }
