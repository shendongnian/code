    public class YourClassThatIsUsingWebBrowser : IDisposable
    {
        private WebBrowser browser;
        private TaskCompletionSource<WebBrowser> asyncBrowser;
        public YourClassThatIsUsingWebBrowser()
        {
            this.browser.DocumentCompleted += AsyncBrowser_DocumentCompleted;
        }
        private void AsyncBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            asyncBrowser.SetResult(browser);
        }
        public async Task<WebBrowser> NavigateAsync(string urlString)
        {
            this.browser.Navigate(urlString);
            return await OnDocumentCompleted(browser);
        }
        public Task<WebBrowser> OnDocumentCompleted(WebBrowser browser)
        {
            asyncBrowser = new TaskCompletionSource<WebBrowser>();
            return asyncBrowser.Task;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.browser.Dispose();
                }
            }
            disposed = true;
        }
    }
