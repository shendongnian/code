    [assembly: ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]
    namespace WKWebView.iOS
    {
    public class MyWebViewRenderer : ViewRenderer<MyWebView, WKWebView>
    {
        WKWebView _wkWebView;
        protected override void OnElementChanged(ElementChangedEventArgs<MyWebView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var config = new WKWebViewConfiguration();
                _wkWebView = new WKWebView(Frame, config);
                SetNativeControl(_wkWebView);
            }
            if (e.NewElement != null)
            {
                Control.LoadRequest(new NSUrlRequest(new NSUrl(Element.Url)));
            }
        }
    }
    }
