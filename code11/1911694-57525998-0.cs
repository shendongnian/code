        protected override void OnCreate(Bundle savedInstanceState)
        {
            // ... //
            // Iniate webview
            WebView web_view = new WebView(this);
            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.Settings.DomStorageEnabled = true;
            // Create custom WebViewClient to override
            web_view.SetWebViewClient(new WebViewOverride(this));
            web_view.LoadUrl(url);
        }
