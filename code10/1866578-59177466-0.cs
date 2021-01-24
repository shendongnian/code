    public class MyWb : Activity
    {
    int count = 1;
    IValueCallback mUploadMessage;
    private static int FILECHOOSER_RESULTCODE = 1;
    protected override void OnCreate (Bundle bundle)
    {
        base.OnCreate (bundle);
        // Set our view from the "main" layout resource
        SetContentView (Resource.Layout.Main);
        // Get our button from the layout resource,
        // and attach an event to it
        Button button = FindViewById<Button> (Resource.Id.myButton);
        button.Click += delegate {
            button.Text = string.Format ("{0} clicks!", count++);
        };
        var chrome = new FileChooserWebChromeClient ((uploadMsg, acceptType, capture) => {
            mUploadMessage = uploadMsg;
            var i = new Intent (Intent.ActionGetContent);
            i.AddCategory (Intent.CategoryOpenable);
            i.SetType ("image/*");
            StartActivityForResult (Intent.CreateChooser (i, "File Chooser"), FILECHOOSER_RESULTCODE);  
        });
        var webview = this.FindViewById<WebView> (Resource.Id.webView1);
        webview.SetWebViewClient (new WebViewClient ());
        webview.SetWebChromeClient (chrome);
        webview.Settings.JavaScriptEnabled = true;
        webview.LoadUrl ("http://www.script-tutorials.com/demos/199/index.html");
    }
    protected override void OnActivityResult (int requestCode, Result resultCode, Intent intent)
    {
        if (requestCode == FILECHOOSER_RESULTCODE) {
            if (null == mUploadMessage)
                return;
            Java.Lang.Object result = intent == null || resultCode != Result.Ok
                ? null
                : intent.Data;
            mUploadMessage.OnReceiveValue (result);
            mUploadMessage = null;
        }
     }
     }
    partial class FileChooserWebChromeClient : WebChromeClient
    {
    Action<IValueCallback, Java.Lang.String, Java.Lang.String> callback;
    public FileChooserWebChromeClient (Action<IValueCallback, Java.Lang.String, Java.Lang.String> callback)
    {
        this.callback = callback;
    }
    //For Android 4.1
    [Java.Interop.Export]
    public void openFileChooser (IValueCallback uploadMsg, Java.Lang.String acceptType, Java.Lang.String capture)
    {
        callback (uploadMsg, acceptType, capture);
    }
    }
