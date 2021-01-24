    [assembly: ExportRenderer(typeof(CustomWebview),typeof(CustomWebviewAndroid))]
    namespace App81.Droid
    {
    
        public class CustomWebviewAndroid : ViewRenderer<CustomWebview, Android.Webkit.WebView> {
    
            Context _context;
    
            public CustomWebviewAndroid(Context context) : base(context)
            {
    
                _context = context;
     
            }
            protected override void OnElementChanged(ElementChangedEventArgs<CustomWebview> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null)
                {
                    if (Control == null)
                    {
                        var webView = new Android.Webkit.WebView(_context);
                        webView.Settings.JavaScriptEnabled = true;
    
                        var cl = new CustomWebViewClient();
                        cl.ErroTeste += (a, b) => {
                            e.NewElement.Test?.Invoke(this, b);
                        };
    
                        webView.SetWebViewClient(cl);
    
                        SetNativeControl(webView);
    
                    }
                   
                    Control.LoadUrl($"https://www.sincor.77seg.com.br/");
                }
            }
        }
    
        public class CustomWebViewClient : WebViewClient
        {
    
    
            public EventHandler<int> ErroTeste;
    
            public override void OnReceivedError(WebView view, IWebResourceRequest request, WebResourceError error)
            {
                ErroTeste?.Invoke(this, 404);
                base.OnReceivedError(view, request, error);
    
            }
    
            public override void OnReceivedHttpError(WebView view, IWebResourceRequest request, WebResourceResponse errorResponse)
            {
                base.OnReceivedHttpError(view, request, errorResponse);
                ErroTeste?.Invoke(this, 404);
            }
        }
    }   
