    protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);
            //Control.LoadUrl("about:blank");
            if (Control == null)
            {
                var webView = new Android.Webkit.WebView(_context);
                webView.Settings.SetSupportZoom(true);
                webView.Settings.BuiltInZoomControls = true;
                webView.Settings.DisplayZoomControls = false;
                webView.Settings.JavaScriptEnabled = true;
                webView.Settings.SetEnableSmoothTransition(true);
                webView.SetWebViewClient(new CustomWebViewClient());
                SetNativeControl(webView);
                Control.LoadUrl(Element.Uri);
            }
        }
