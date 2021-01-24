    async private void WebView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            string html = await webview.InvokeScriptAsync("eval", new string[] { "document.documentElement.outerHTML;" });
            _html = html; //A property of your class to store the value when the event is fired
        }
