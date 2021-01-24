    public class CustomWKNavigationDelegate : WKNavigationDelegate
        {
    
            CustomWebViewRenderer _webViewRenderer;
    
            public CustomWKNavigationDelegate(CustomWebViewRenderer webViewRenderer)
            {
                _webViewRenderer = webViewRenderer;
            }
    
            public  override async void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
           {
                var wv = _webViewRenderer.Element as PostWebView;
                if (wv != null)
                {
                    await System.Threading.Tasks.Task.Delay(100); // wait here till content is rendered
                    wv.HeightRequest = (double)webView.ScrollView.ContentSize.Height;
                }
            }
        }
