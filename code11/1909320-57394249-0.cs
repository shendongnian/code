public class HybridWebView : View
{
  Action<int, string, bool> action;
  public static readonly BindableProperty UriProperty = BindableProperty.Create (
    propertyName: "Uri",
    returnType: typeof(string),
    declaringType: typeof(HybridWebView),
    defaultValue: default(string));
  public string Uri {
    get { return (string)GetValue (UriProperty); }
    set { SetValue (UriProperty, value); }
  }
  public void RegisterAction (Action<int, string, bool> callback)
  {
    action = callback;
  }
  public void Cleanup ()
  {
    action = null;
  }
  public void InvokeAction (int a,string b,bool c)
  {
    if (action == null ) {
      return;
    }
    action.Invoke (a,b,c);
  }
}
>in ContentPage
The HybridWebView instance will be used to display a native web control on each platform. It's Uri property is set to an HTML address , and which will be displayed by the native web control.
The HybridWebViewPage registers the action to be invoked from JavaScript, as shown in the following code example:
public partial class xxxPage : ContentPage
{
  public xxxPage ()
  {
    //...
    hybridWebView.RegisterAction ((a,b,c) => simpleMethod(a,b,c));
  }
  public void simpleMethod(int a,string b,bool c)
  {
     string[] data;
     if(c){
        data[a] = b;
      }
  }
}
<ContentPage.Content>
   <local:HybridWebView x:Name="hybridWebView" Uri="https://docs.microsoft.com"
          HorizontalOptions="FillAndExpand" VerticalOptions="FillAndExpand" />
</ContentPage.Content>
>in your html file
For example you want to call the method when click a button
<button type="button" onclick="javascript:invokeCSCode(a,b,c);">Invoke C# Code</button>
//...
function invokeCSCode(a,b,c) {
    try {
       
        invokeCSharpAction(a,b,c);
    }
    catch (err){
          log(err);
    }
}
>Creating the Custom Renderer on iOS
[assembly: ExportRenderer (typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace CustomRenderer.iOS
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, WKWebView>, IWKScriptMessageHandler
    {
        const string JavaScriptFunction = "function invokeCSharpAction(a,b,c){window.webkit.messageHandlers.invokeAction.postMessage(a,b,c);}";
        WKUserContentController userController;
        protected override void OnElementChanged (ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged (e);
            if (e.OldElement != null) {
                userController.RemoveAllUserScripts ();
                userController.RemoveScriptMessageHandler ("invokeAction");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup ();
            }
            if (e.NewElement != null) {
                if (Control == null) {
                    userController = new WKUserContentController ();
                    var script = new WKUserScript (new NSString (JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
                    userController.AddUserScript (script);
                    userController.AddScriptMessageHandler (this, "invokeAction");
                    var config = new WKWebViewConfiguration { UserContentController = userController };
                    var webView = new WKWebView (Frame, config);
                    SetNativeControl (webView);
                }
                
                Control.LoadRequest (new NSUrlRequest (new NSUrl (Element.Uri, false)));
            }
        }
        public void DidReceiveScriptMessage (WKUserContentController userContentController, WKScriptMessage message)
        {
            Element.InvokeAction (message.Body.ToString ());
        }
    }
}
In addition, **Info.plist** must be updated to include the following values:
<key>NSAppTransportSecurity</key>
<dict>
	<key>NSAllowsArbitraryLoads</key>
	<true/>
</dict>
>Creating the Custom Renderer on Android
[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace CustomRenderer.Droid
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, Android.Webkit.WebView>
    {
        const string JavascriptFunction = "function invokeCSharpAction(a,b,c){jsBridge.invokeAction(a,b,c);}";
        Context _context;
        public HybridWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var webView = new Android.Webkit.WebView(_context);
                    webView.Settings.JavaScriptEnabled = true;
                    webView.SetWebViewClient(new JavascriptWebViewClient($"javascript: {JavascriptFunction}"));
                    SetNativeControl(webView);
                }
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
                Control.LoadUrl(Element.Uri);
            }
        }
    }
}
public class JavascriptWebViewClient : WebViewClient
{
    string _javascript;
    public JavascriptWebViewClient(string javascript)
    {
        _javascript = javascript;
    }
    public override void OnPageFinished(WebView view, string url)
    {
        base.OnPageFinished(view, url);
        view.EvaluateJavascript(_javascript, null);
    }
}
public class JSBridge : Java.Lang.Object
{
  readonly WeakReference<HybridWebViewRenderer> hybridWebViewRenderer;
  public JSBridge (HybridWebViewRenderer hybridRenderer)
  {
    hybridWebViewRenderer = new WeakReference <HybridWebViewRenderer> (hybridRenderer);
  }
  [JavascriptInterface]
  [Export ("invokeAction")]
  public void InvokeAction (int a,string b,bool c)
  {
    HybridWebViewRenderer hybridRenderer;
    if (hybridWebViewRenderer != null && hybridWebViewRenderer.TryGetTarget (out hybridRenderer))
    {
      hybridRenderer.Element.InvokeAction (a,b,c);
    }
  }
}
