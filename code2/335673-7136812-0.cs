        public static IObservable<int> DownloadURL(string url,string fname)
        {
            return Observable.Defer(() =>
            {
                var sub = new Subject<int>();
                var wc = new WebClient();
                wc.DownloadProgressChanged += delegate(object sender, DownloadProgressChangedEventArgs e)
                {
                    sub.OnNext(e.ProgressPercentage);
                    if (e.ProgressPercentage == 100)
                        sub.OnCompleted();
                };
                wc.DownloadFileAsync(new Uri(url), fname);
                return sub;
            });
        }
    
        public static void Main(string[] str)
        {
            foreach (var i in DownloadURL("http://www.google.com", "g:\\google.html").DistinctUntilChanged().ToEnumerable())
                Console.WriteLine(i);
        }
