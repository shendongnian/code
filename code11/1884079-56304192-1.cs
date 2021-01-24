    ...
     protected override void OnElementChanged(ElementChangedEventArgs<PostWebView> e)
            {
                base.OnElementChanged(e);
               
      
                if (Control == null)
                {
                    WKWebViewConfiguration config = new WKWebViewConfiguration();
    
                    _wkWebView = new WKWebView(Frame, config);
                    _wkWebView.NavigationDelegate = new CustomNavigationDelegate(this);
    ...
