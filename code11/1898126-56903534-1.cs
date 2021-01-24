          if (Control == null)
            {
                var webView = new Android.Webkit.WebView(_context);
                webView.Settings.JavaScriptEnabled = true;
                webView.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavascriptFunction}"));
                ////////////////////////add here 
                webView.SetWebChromeClient(new WebChromeClient());
                MessagingCenter.Subscribe<object, string>(this, "Hi", (obj, arg) =>
                {
                    webView.EvaluateJavascript(arg, null);
                });
                ///////////////////////
                SetNativeControl(webView);
               
            }
