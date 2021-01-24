    [assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
    namespace DipsDemoXaml.Droid.Renderer
    
    public class CustomWebViewRenderer : WebViewRenderer
    {
        public CustomWebViewRenderer(Context context) : base(context)
        { 
        }
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {              
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.BuiltInZoomControls = true;
                Control.Settings.DisplayZoomControls = true;
              
            }
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Uri") return;
            var customWebView = Element as CustomWebView;
            if (customWebView != null)
            {
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(customWebView.Uri))));        
            }
        }
        
    }
