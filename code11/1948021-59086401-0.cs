    class CustomWebViewClient : WebViewClient
    {
            bool pageCommitted = false;
            public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                if (!pageCommitted)
                {
                    view.LoadUrl(url);
                }
                base.OnPageFinished(view, url);
            }
            public override void OnPageCommitVisible(Android.Webkit.WebView view, string url)
            {
                pageCommitted = true;
            }
    }
