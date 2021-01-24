    [assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
    
    {
        public class CustomWebViewRenderer : WebViewRenderer
        {
            public CustomWebViewRenderer(Context context) : base(context) { }
    
            protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null)
                {
                    var customWebView = Element as CustomWebView;
                    if (File.Exists(customWebView.Uri))
                    {
                        Control.Settings.AllowUniversalAccessFromFileURLs = true;
                        var finalStr = string.Format(
                                "file:///android_asset/pdfjs/web/viewer.html?file={0}",
                                string.Format(
                                    "file:///{0}",
                                    WebUtility.UrlEncode(customWebView.Uri)
                                )
                            );
                        Control.LoadUrl(finalStr);
                    }
                }
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                if (e.PropertyName == "Uri")
                {
                    var customWebView = Element as CustomWebView;
                    if (File.Exists(customWebView.Uri))
                    {
                        Control.Settings.AllowUniversalAccessFromFileURLs = true;
                        var finalStr = string.Format(
                                "file:///android_asset/pdfjs/web/viewer.html?file={0}",
                                string.Format(
                                    "file:///{0}",
                                    WebUtility.UrlEncode(customWebView.Uri)
                                )
                            );
                        Control.LoadUrl(finalStr);
                    }
                }
            }
        }
    }
