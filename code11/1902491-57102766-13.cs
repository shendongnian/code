    public static class WebBrowserExtensions
    {
        public static Task<Uri> DocumentCompletedAsync(this WebBrowser wb)
        {
            var tcs = new TaskCompletionSource<Uri>();
            WebBrowserDocumentCompletedEventHandler handler = null;
            handler = (_, e) =>
            {
                wb.DocumentCompleted -= handler;
                tcs.TrySetResult(e.Url);
            };
            wb.DocumentCompleted += handler;
            return tcs.Task;
        }
    }
