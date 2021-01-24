    private HybridWebView xfWebView;
    protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);
    
            if (Control == null)
            {
                var webView = new Android.Webkit.WebView(_context);
                webView.Settings.JavaScriptEnabled = true;
                webView.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavascriptFunction}"));
                SetNativeControl(webView);
    
    
            }
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
    
                e.OldElement.CallJavascript += OnElementCallJavascript;
            }
            if (e.NewElement != null)
            {
                xfWebView = e.NewElement;
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
                if (xfWebView != null)
                    {
                        xfWebView.EvaluateJavascript = async (js) =>
                        {
                            var reset = new ManualResetEvent(false);
                            var response = string.Empty;
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                Control?.EvaluateJavascript(js, new JavascriptCallback((r) => { response = r; reset.Set(); }));
                            });
                            await Task.Run(() => { reset.WaitOne(); });
                            return response;
                        };
                    }
             Control.LoadUrl($"file:///android_asset/Content/{Element.Uri}");
            }
    }
