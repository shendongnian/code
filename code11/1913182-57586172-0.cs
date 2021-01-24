    protected override void OnCreate(Bundle savedInstanceState)
        {      
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_other);           
            webView = FindViewById<WebView>(Resource.Id.webView1);
            webView.SetWebViewClient(new WebViewClientClass());
            WebSettings websettings = webView.Settings;
            websettings.JavaScriptEnabled = true;
            websettings.DomStorageEnabled = true;
            webView.AddJavascriptInterface(new Foo(this), "Foo");
            webView.LoadUrl("file:///android_asset/demo.html");
        }
    class WebViewClientClass : WebViewClient
        {
            public override void OnReceivedHttpAuthRequest(WebView view, HttpAuthHandler handler, string host, string realm)
            {
            }
            public override void OnPageFinished(WebView view, string url)
            {
                view.LoadUrl("javascript:window.Foo.showSource("
                             + "document.getElementsByTagName('html')[0].innerHTML);");
                base.OnPageFinished(view, url);
            }
        }
    class Foo : Java.Lang.Object
    {
        Context context;
        public Foo(Context context)
        {
            this.context = context;
        }
        [JavascriptInterface]
        [Export]
        public void showSource(string html)
        {
            Log.Error("content", html);//here html is the HTML code
        }
    }
