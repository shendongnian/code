    public MainPage()
            {
                InitializeComponent();
    
                GetFileContent("http://localhost/test/myjson.txt", ProcessResult, error => { throw error; });
            }
    
            private void ProcessResult(String result)
            {
                //Do stuff here
            }
    
            private void GetFileContent(String uri, Action<String> onData, Action<Exception> onError)
            {
                var wc = new WebClient();
                
                DownloadStringCompletedEventHandler handler = null;
    
                handler = (s, args) =>
                {
                    wc.DownloadStringCompleted -= handler;
                    if(args.Error != null)
                    {
                        if(onError != null)
                            onError(args.Error);
                        return;
                    }
    
                    if(onData != null)
                        onData(args.Result);
                };
                wc.DownloadStringCompleted += handler;
