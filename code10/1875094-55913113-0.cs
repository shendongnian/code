using Xamarin.Forms;
namespace xxx
{
    public class MyWebview:WebView
    {
        public string data; //Parameters that you want to pass
        public string url;
        public MyWebview()
        {
        }
    }
}
in contentPage
public MainPage()
{
   InitializeComponent();
   Content = new StackLayout
     {
        Children =
          {
            new MyWebview()
             {
               url="your url",
               WidthRequest = 300,
               HeightRequest = 500,
               data = "userName=xxx"
              },
          },
          VerticalOptions = LayoutOptions.FillAndExpand,
          HorizontalOptions=LayoutOptions.FillAndExpand
                
      };
}
> in iOS project
using Foundation;
using UIKit;
using xxx;
using xxx.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly:ExportRenderer(typeof(MyWebview),typeof(MyWebViewRenderer))]
namespace xxx.iOS
{
    public class MyWebViewRenderer:WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if(NativeView!=null)
            {
                var mywebview = Element as MyWebview;
                var request = new NSMutableUrlRequest(new NSUrl(new NSString(mywebview.url)));
                request.Body = mywebview.data;
                request.HttpMethod = "POST";
                LoadRequest(request);
            }
        }        
    }
}
**Notes**
For iOS 9 onwards and MacOS, if you wish to access unsecure sites you may need to configure or disable ATS
    <key>NSAppTransportSecurity</key>
    <dict>
    <key>NSAllowsArbitraryLoads</key><true/>
    </dict>
> in Android Project
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using xxx;
using xxx.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(MyWebview), typeof(MyWebViewRenderer))]
namespace xxx.Droid
{
    public class MyWebViewRenderer:WebViewRenderer
    {
        public MyWebViewRenderer(Context context):base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                var mywebview = Element as MyWebview;
                var postData = Encoding.UTF8.GetBytes(mywebview.data);
                Control.PostUrl(mywebview.url, postData);
            }
        }
    }
}
For more detail about custom renderer you can refer to [here][1].
  [1]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/
