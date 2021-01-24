    public override void OnResume()
    {
    	base.OnResume();
    
    	wv = view.FindViewById<WebView>(Resource.Id.webView);
    
    	((MainActivity)this.Activity).OpenURL(this);
    }
