       public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            WKWebView webView = new WKWebView(View.Frame, new WKWebViewConfiguration());
            View.AddSubview(webView);
            View.SendSubviewToBack(webView);
            webView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
            var url = new NSUrl("link");
            var request = new NSUrlRequest(url);
            webView.LoadRequest(request);
            webView.AllowsBackForwardNavigationGestures = true;
            //assign delegate
            webView.NavigationDelegate = new MyWKNavigationDelegate();
        }
     //custom delegate
     class MyWKNavigationDelegate : WKNavigationDelegate
     {
          
        [Export("webView:decidePolicyForNavigationAction:decisionHandler:")]
        public override void DecidePolicy(WKWebView webView, WKNavigationAction 
        navigationAction, Action<WKNavigationActionPolicy> decisionHandler)
        {
            var navType = navigationAction.NavigationType;
            var targetFrame = navigationAction.TargetFrame;
            var url = navigationAction.Request.Url;
            if (
                url.ToString().StartsWith("http") && (targetFrame != null && 
            targetFrame.MainFrame == true)
                )
            {
                decisionHandler(WKNavigationActionPolicy.Allow);
            }
            else if (
                //(url.ToString().StartsWith("http") && targetFrame == null)
                //||
                url.ToString().StartsWith("mailto:")
                || url.ToString().StartsWith("tel:")
                || url.ToString().StartsWith("Tel:"))
            {
                //decisionHandler(WKNavigationActionPolicy.Allow);
     
                    UIApplication.SharedApplication.OpenUrl(url);         
            }
            
        }
     }
