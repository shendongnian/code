    [assembly: ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]
    namespace App18.Droid
    {
      class MyWebViewRenderer : ViewRenderer<MyWebView, Android.Webkit.WebView>,View.IOnTouchListener
       {
          private Context _context;
          private float preX;
          private float curX;
          private static int MIN_CLICK_DELAY_TIME = 1000;
          private long lastClickTime = 0;
          public MyWebViewRenderer(Context context) : base(context)
           {
            _context = context;
           }
          public bool OnTouch(View v, MotionEvent e)
           {
            if (e.Action == MotionEventActions.Down)
             {
                Toast.MakeText(_context, "click", ToastLength.Short).Show();
                preX = e.RawX;
              
             }
            if (e.Action == MotionEventActions.Up)
             {
                curX = e.RawX;
                long currentTime = Calendar.Instance.TimeInMillis;
                if (currentTime - lastClickTime < MIN_CLICK_DELAY_TIME)
                {
                    
                    Toast.MakeText(_context, "double click", ToastLength.Short).Show();
                }
                lastClickTime = currentTime;
                Log.Error("time", currentTime + "-----------" + lastClickTime);
                //the distance you could define your own,here is 200,and just a simple judgment of the x direction
                if ((curX - preX) > 200)
                {
                    Toast.MakeText(_context, "swipe right", ToastLength.Short).Show();
                }
                if ((curX - preX) < -200)
                {
                    Toast.MakeText(_context, "swipe left", ToastLength.Short).Show();
                }
               
             }
            return false;
          }
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<MyWebView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var webView = new Android.Webkit.WebView(_context);
                SetNativeControl(webView);
                webView.LoadUrl("https://www.google.com");
                webView.SetOnTouchListener(this);
            }
        }
      }
    }
