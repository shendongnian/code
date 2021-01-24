    [assembly: ExportRenderer (typeof (MyWebView), typeof (MyWebViewRenderer))]
    namespace App374.Droid
    {
        public class MyWebViewRenderer : WebViewRenderer
        {
            public MyWebViewRenderer(Context context) : base(context)
            {
            }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
            {
                base.OnElementChanged(e);
                if (e.OldElement == null)
                {
                    // lets get a reference to the native control
                    var webView = (global::Android.Webkit.WebView)Control;
                    webView.SetWebViewClient(new MyWebViewClient());
                    webView.SetInitialScale(0);
                    webView.Settings.JavaScriptEnabled = true;
                }
            }
        }
    
        public class MyWebViewClient : WebViewClient
        {
            public override void OnPageFinished(Android.Webkit.WebView view, string url)
            {
                base.OnPageFinished(view, url);
    
                MainPage.CurrentUrl = url;
    
                MainPage.checkToShowButton();
            }
        }
    }
