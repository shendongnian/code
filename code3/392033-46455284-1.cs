    public class YourClassThatIsUsingWebBrowser : IDisposable
    {
        private WebBrowser browser;
        private TaskCompletionSource<BrowserResult> tcs;
        public YourClassThatIsUsingWebBrowser()
        {
            this.browser.DocumentCompleted += AsyncBrowser_DocumentCompleted;
            this.browser.Document.Window.Error += (errorSender, errorEvent) =>
            {
                SetResult(BrowserResult.Exception, errorEvent.Description);
            };
            this.browser.PreviewKeyDown += Browser_PreviewKeyDown;
            this.browser.Navigating += Browser_Navigating;
        }
        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            tcs = new TaskCompletionSource<BrowserResult>();
        }
         
        private void Browser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.browser.Stop();
                SetResult(BrowserResult.Cancelled);
            }
        }
        private void AsyncBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            SetResult();
        }
        public async Task<BrowserResult> NavigateAsync(string urlString)
        {
            this.browser.Navigate(urlString);
            return await tcs.Task;
        }
        private void SetResult(BrowserResult result = BrowserResult.Succeed, string error = null)
        {
            if (tcs == null)
            {
                return;
            }
            switch (result)
            {
                case BrowserResult.Cancelled:
                    {
                        tcs.SetCanceled();
                        break;
                    }
                case BrowserResult.Exception:
                    {
                        tcs.SetException(new Exception(error));
                        break;
                    }
                case BrowserResult.Succeed:
                default:
                    {
                        tcs.SetResult(result);
                        break;
                    }
            }
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
    public enum BrowserResult
    {
        Succeed,
        Cancelled,
        Exception,
    }
