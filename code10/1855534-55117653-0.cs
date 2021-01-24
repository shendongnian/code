    private async Task<string> GetContent()
    {
        string content;
        using (SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0, 1))
        {
            async void handler(WebView sender, WebViewNavigationCompletedEventArgs args)
            {
                content = await webView.InvokeScriptAsync("eval", new string[] { script });
                webView.NavigationCompleted -= handler;
                semaphoreSlim.Release();
            }
            webView.NavigationCompleted += handler;
            webView.Navigate(uri);
            await semaphoreSlim.WaitAsync().ConfigureAwait(false);
        }
        return content;
    }
