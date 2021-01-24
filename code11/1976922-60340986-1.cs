public class MyLoginWebPageModel : BasePageModel
    {
        private BrowserOptions _options;
        private Action<BrowserResult> _trySetResult;
        private BrowserResult _result = new BrowserResult() { ResultType = BrowserResultType.UserCancel };
        private Boolean _navPopped = false;
        public string StartUrl { get; private set; }
        private bool _loading { get; set; }    //HERE IS THE CHANGE
        public bool Loading { get {return _loading; } set{value = _loading } }   //HERE IS THE CHANGE
        public OidcLoginWebPageModel(ICoreDataRepository repository, ILoginProvider loginProvider, ICache cache, IEventTrace trace, IUsageTimer usageTimer, IPlatform platform)
            : base(loginProvider, cache, trace, usageTimer, platform){}
        public override void Init(object initData)
        {
            base.Init(initData);
            Tuple<BrowserOptions, Action<BrowserResult>> initObject = initData as Tuple<BrowserOptions, Action<BrowserResult>>;
            _options = initObject.Item1;
            _trySetResult = initObject.Item2;
            StartUrl = _options.StartUrl;
        }
        protected override void OnPageWasPopped(object sender, EventArgs e)
        {
            base.OnPageWasPopped(sender, e);
            _trySetResult(_result);
        }
        internal async Task OnBrowserNavigated(object sender, WebNavigatedEventArgs e)
        {
            Loading = false;
            if (!(sender is WebView browser))
            {
                throw new Exception($"Sender is not of type WebView");
            }
            if (!Uri.TryCreate(e.Url, UriKind.Absolute, out Uri uri))
            {
                throw new Exception($"Uri creation failed for: {e.Url}");
            }
            if (string.IsNullOrEmpty(_options.EndUrl))
            {
                if (uri.LocalPath.ToLowerInvariant() == "/account/logout")
                {
                    _result = new BrowserResult() { ResultType = BrowserResultType.Success };
                    if (!_navPopped)
                    {
                        _navPopped = true;
                        await PopPageModel();
                    }
                }
            }
        }
        internal async Task OnBrowserNavigating(object sender, WebNavigatingEventArgs e)
        {
            Loading = true;
            if (!(sender is WebView browser))
            {
                Loading = false;
                throw new Exception($"Sender is not of type WebView");
            }
            if (!Uri.TryCreate(e.Url, UriKind.Absolute, out Uri uri))
            {
                Loading = false;
                throw new Exception($"Uri creation failed for: {e.Url}");
            }
            if (string.IsNullOrEmpty(_options.EndUrl) == false)  //IF THE CONDITION OVER HERE & FOR INNER IF CONDITIONS FAILS, LOADER WASNT SET TO FALSE 
            {
                if (uri.AbsoluteUri.StartsWith(_options.EndUrl))
                {
                    _result = new BrowserResult() { ResultType = BrowserResultType.Success, Response = uri.Fragment.Substring(1) };
                    e.Cancel = true;
                    if (!_navPopped)
                    {
                        _navPopped = true;
                        Loading = false;
                        await PopPageModel();
                    }
                }
            }
            Loading = false;
        }
    }
