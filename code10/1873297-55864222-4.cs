    webView = FindViewById<WebView>(Resource.Id.webView1);
    webView.Settings.JavaScriptEnabled = true;
    webView.SetWebViewClient(new HelloWebViewClient());
    webView.LoadUrl("https://www.xamarin.com/university");
    webView.SetDownloadListener(new downloadListener());
