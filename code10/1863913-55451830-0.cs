    public BrowserTabViewModel(string address)
            {
                Address = address;
                AddressEditable = Address;
    
                GoCommand = new RelayCommand(Go, () => !String.IsNullOrWhiteSpace(Address));
                HomeCommand = new RelayCommand(() => AddressEditable = Address = CefExample.DefaultUrl);
                ExecuteJavaScriptCommand = new RelayCommand<string>(ExecuteJavaScript, s => !String.IsNullOrWhiteSpace(s));
                EvaluateJavaScriptCommand = new RelayCommand<string>(EvaluateJavaScript, s => !String.IsNullOrWhiteSpace(s));
                ShowDevToolsCommand = new RelayCommand(() => webBrowser.ShowDevTools());
                CloseDevToolsCommand = new RelayCommand(() => webBrowser.CloseDevTools());
                JavascriptBindingStressTest = new RelayCommand(() =>
                {
                    WebBrowser.Load(CefExample.BindingTestUrl);
                    WebBrowser.LoadingStateChanged += (e, args) =>
                    {
                        if (args.IsLoading == false)
                        {
                            Task.Delay(10000).ContinueWith(t =>
                            {
                                WebBrowser.Reload();
                            });
                        }
                    };
                });
    
                PropertyChanged += OnPropertyChanged;
    
                var version = string.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion);
                OutputMessage = version;
            }
