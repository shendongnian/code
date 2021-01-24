        public static async Task RunWithoutBlocking(IEnumerable<Func<Task>> actions)
        {
            var currentSyncContext = SynchronizationContext.Current;
            try
            {
                SynchronizationContext.SetSynchronizationContext(null);
                foreach (var action in actions)
                {
                    await action();
                }
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(currentSyncContext);
            }
        }`
