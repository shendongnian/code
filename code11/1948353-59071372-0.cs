using Android.App;
using Android.Content;
using Android.Net.Http;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using xxx;
using xxx.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(Xamarin.Forms.WebView), typeof(CustomWebViewRenderer))]
namespace xxx.Droid
{
    public class MyWebChromeClient : WebChromeClient
    {
        
        public override void OnPermissionRequest(PermissionRequest request)
        {
            base.OnPermissionRequest(request);
            request.Grant(request.GetResources());
        }
    }
   
    public class CustomWebViewRenderer : WebViewRenderer
    {
        public CustomWebViewRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var customWebView = Element as Xamarin.Forms.WebView;
               // Control.SetBackgroundColor (Android.Graphics.Color.Red);
                             
                Control.Settings.JavaScriptEnabled = true;
                Control.SetWebChromeClient(new MyWebChromeClient());
            }
        }
    }
}
