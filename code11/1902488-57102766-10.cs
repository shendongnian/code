    public static class WebBrowserExtensions
    {
        public static Task<Uri> DocumentCompletedAsync(this WebBrowser wb, int timeout)
        {
            var tcs = new TaskCompletionSource<Uri>();
            WebBrowserDocumentCompletedEventHandler handler = null;
            var timeoutRegistration = WithTimeout(tcs, timeout,
                () => wb.DocumentCompleted -= handler);
            handler = (_, e) =>
            {
                wb.DocumentCompleted -= handler;
                timeoutRegistration.Unregister();
                tcs.TrySetResult(e.Url);
            };
            wb.DocumentCompleted += handler;
            return tcs.Task;
        }
        public static Task<Uri> DocumentCompletedAsync(this WebBrowser wb)
        {
            return wb.DocumentCompletedAsync(30000); // Default timeout 30 sec
        }
        private static TimeoutRegistration WithTimeout<T>(
            TaskCompletionSource<T> tcs, int timeout, Action eventRemove)
        {
            if (timeout == Timeout.Infinite) return default;
            var timer = new System.Windows.Forms.Timer();
            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer = null;
                tcs.SetException(new TimeoutException());
                tcs = null;
                eventRemove();
                eventRemove = null;
            };
            timer.Interval = timeout;
            timer.Enabled = true;
            return new TimeoutRegistration(() =>
            {
                if (timer == null) return;
                timer.Enabled = false;
                // Make everything null to avoid memory leaks
                timer = null;
                tcs = null;
                eventRemove = null;
            });
        }
        private struct TimeoutRegistration
        {
            private Action _unregister;
            public TimeoutRegistration(Action unregister)
            {
                _unregister = unregister;
            }
            public void Unregister()
            {
                if (_unregister == null) return;
                _unregister();
                _unregister = null;
            }
        }
    }
