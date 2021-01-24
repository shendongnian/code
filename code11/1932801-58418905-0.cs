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
                var asyncArgs = new FormClosingAsyncEventArgs(e.CloseReason);
                var handlerTask = Task.Factory.StartNew(() => handler(sender, asyncArgs),
                    CancellationToken.None, TaskCreationOptions.DenyChildAttach,
                    TaskScheduler.Default).Result; // Start in a thread-pool thread
                e.Cancel = true; // Cancel the normal closing of the form
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
    public class FormClosingAsyncEventArgs : FormClosingEventArgs
    {
        public bool HideForm { get; set; }
        public int Timeout { get; set; }
        public FormClosingAsyncEventArgs(CloseReason closeReason)
            : base(closeReason, false)
        { this.Timeout = System.Threading.Timeout.Infinite; }
    }
