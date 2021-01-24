    using Android.Content;
    using Android.Runtime;
    using Android.Util;
    using Android.Webkit;
    using System;
    namespace f00ProjectNamespace
    {
    public class ExtWebView : WebView
    {
        //from what I read you need all of the constructors..
        //so type ExtWebView : WebView then right click on ExtWebView and hit
        //"generate all" *after* adding "using Android.Webkit;"
        public ExtWebView(Context context) : base(context)
        {
        }
        public ExtWebView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }
        public ExtWebView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }
        public ExtWebView(Context context, IAttributeSet attrs, int defStyleAttr, bool privateBrowsing) : base(context, attrs, defStyleAttr, privateBrowsing)
        {
        }
        public ExtWebView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }
        protected ExtWebView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        //now we can override methods inside the WebView like this: =]
        public override void OnWindowFocusChanged(bool hasWindowFocus)
        {
            //this method is invoked when the app changes focus
            base.OnWindowFocusChanged(hasWindowFocus);
        }
    }
    }
