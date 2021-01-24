    public partial class MyCustomWebView : Android.Webkit.WebView
    {
        protected MyCustomWebView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            MakeSettings();
        }
        public MyCustomWebView(Context context) : base(context)
        {
            MakeSettings();
        }
        public MyCustomWebView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            MakeSettings();
        }
        public MyCustomWebView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            MakeSettings();
        }
        public MyCustomWebView(Context context, IAttributeSet attrs, int defStyleAttr, bool privateBrowsing) : base(context, attrs, defStyleAttr, privateBrowsing)
        {
            MakeSettings();
        }
        public MyCustomWebView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            MakeSettings();
        }
        private void MakeSettings()
        {
            SetLayerType(LayerType.Hardware, null);
            ForceHasOverlappingRendering(true);
            SetWebViewClient(new MyCustomWebViewClient(this));
            SetWebChromeClient(new WebChromeClient());
            Settings.AllowFileAccessFromFileURLs = true;
            Settings.AllowUniversalAccessFromFileURLs = true;
            Settings.JavaScriptEnabled = true;
            Settings.DomStorageEnabled = true;
            Settings.AllowFileAccess = true;
            Settings.CacheMode = CacheModes.NoCache;
            Settings.MediaPlaybackRequiresUserGesture = false;
            Settings.SetPluginState(WebSettings.PluginState.On);
        }
        public string HtmlContent
        {
            get { return string.Empty; }
            set { LoadUrl(value); }
        }
    }
    public class MyCustomWebViewClient : Android.Webkit.WebViewClient
    {
        public MyCustomWebViewClient(WebView view)
        {
            var test = view.IsHardwareAccelerated;
            view.SetLayerType(LayerType.Hardware, null);
        }
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl(request.Url.ToString());
            return true;
        }
        public override void OnPageStarted(WebView view, string url, Bitmap favicon)
        {
            // The native webview control requires to have LayoutParameters to function properly.
            view.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            base.OnPageStarted(view, url, favicon);
        }
    }
