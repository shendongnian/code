    using System;
    using Android.App;
    using Android.OS;
    using Android.Webkit;
    
    namespace XamdroidMaster.Activities {
    
        [Activity(Label = "Custom WebViewClient", MainLauncher = true)]
        public class WebViewCustomActivity : Activity {
    
            protected override void OnCreate(Bundle savedInstanceState) {
                base.OnCreate(savedInstanceState);
    
                SetContentView(Resource.Layout.WebView);
                WebView wv = FindViewById<WebView>(Resource.Id.webviewMain);
    
                CustomWebViewClient customWebViewClient = new CustomWebViewClient();
                customWebViewClient.OnPageLoaded += CustomWebViewClient_OnPageLoaded;
                
                wv.SetWebViewClient(customWebViewClient);
                wv.LoadUrl("https://www.stackoverflow.com");
            }
    
            private void CustomWebViewClient_OnPageLoaded(object sender, string sTitle) {
                Android.Util.Log.Info("MyApp", $"OnPageLoaded Fired - Page Title = {sTitle}");
            }
    
        }
    
        public class CustomWebViewClient : WebViewClient {
    
            public event EventHandler<string> OnPageLoaded;
    
            public override void OnPageFinished(WebView view, string url) {
                OnPageLoaded?.Invoke(this, view.Title);
            }
    
        }
    
    }
