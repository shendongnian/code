    static class WindowsFormsAsyncExtensions
    {
        public static IDisposable OnFormClosingAsync(this Form form,
            Func<object, FormClosingAsyncEventArgs, Task> handler)
        {
            Task compositeTask = null;
            form.FormClosing += OnFormClosing; // Subscribe to the event
            return new Disposer(() => form.FormClosing -= OnFormClosing);
            async void OnFormClosing(object sender, FormClosingEventArgs e)
            {
                if (compositeTask != null)
                {
                    // Prevent the form from closing before the task is completed
                    if (!compositeTask.IsCompleted) { e.Cancel = true; return; }
                    // In case of success allow the form to close
                    if (compositeTask.Status == TaskStatus.RanToCompletion) return;
                    // Otherwise retry calling the handler
                }
                e.Cancel = true; // Cancel the normal closing of the form
                var asyncArgs = new FormClosingAsyncEventArgs(e.CloseReason);
                var handlerTask = await Task.Factory.StartNew(
                    () => handler(sender, asyncArgs),
                    CancellationToken.None, TaskCreationOptions.DenyChildAttach,
                    TaskScheduler.Default); // Start in a thread-pool thread
                var hideForm = asyncArgs.HideForm;
                var timeout = asyncArgs.Timeout;
                if (hideForm) form.Visible = false;
                compositeTask = Task.WhenAny(handlerTask, Task.Delay(timeout)).Unwrap();
                try
                {
                    await compositeTask; // Await and then continue in the UI thread
                }
                catch (OperationCanceledException) // Treat this as Cancel = true
                {
                    if (hideForm) form.Visible = true;
                    return;
                }
                catch // On error don't leave the form hidden
                {
                    if (hideForm) form.Visible = true;
                    throw;
                }
                if (asyncArgs.Cancel) // The caller requested to cancel the form close
                {
                    compositeTask = null; // Forget the completed task
                    if (hideForm) form.Visible = true;
                    return;
                }
                await Task.Yield(); // Ensure that form.Close will run asynchronously
                form.Close(); // Finally close the form
            }
        }
        private struct Disposer : IDisposable
        {
            private readonly Action _action;
            public Disposer(Action disposeAction) => _action = disposeAction;
            void IDisposable.Dispose() => _action?.Invoke();
        }
    }
    public class FormClosingAsyncEventArgs : EventArgs
    {
        public CloseReason CloseReason { get; }
        private volatile bool _cancel;
        public bool Cancel { get => _cancel; set => _cancel = value; }
        private volatile bool _hideForm;
        public bool HideForm { get => _hideForm; set => _hideForm = value; }
        private volatile int _timeout;
        public int Timeout { get => _timeout; set => _timeout = value; }
        public FormClosingAsyncEventArgs(CloseReason closeReason) : base()
        {
            this.CloseReason = closeReason;
            this.Timeout = System.Threading.Timeout.Infinite;
        }
    }
