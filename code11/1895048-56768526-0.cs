    [assembly: ExportRenderer(typeof(myWebView), typeof(myWebRender))]
    
    namespace App452.iOS
    {
        class myWebRender :  WebViewRenderer
        {
    
            protected override void OnElementChanged(VisualElementChangedEventArgs e)
            {
                base.OnElementChanged(e);
    
                if (e.OldElement == null)
                {   // perform initial setup
                    UIWebView myWebView = (UIWebView)this.NativeView;
    
                    myWebView.Delegate = new CustomWebViewDelegate();             
                }
            }
    
            public class CustomWebViewDelegate : UIWebViewDelegate
            {
                public CustomWebViewDelegate()
                {
                }
    
                public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
                {
    
                    Console.WriteLine(request.Url.AbsoluteString);
                    //Handle your logic here
    
                    return base.ShouldStartLoad(webView, request, navigationType);
                }
    
            }
        }
    }
