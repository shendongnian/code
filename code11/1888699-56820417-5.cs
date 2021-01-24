        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var _view = inflater.Inflate(Resource.Layout.TheFragmentLayout1, container, false);
            var _viewMain = inflater.Inflate(Resource.Layout.Main, container, false);
            var _wv = (ExtWebView)_view.FindViewById<ExtWebView>(Resource.Id.webView1);
        }
