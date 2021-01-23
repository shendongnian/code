            Func<string, IObservable<WebResponse>> createRequestObservable = 
                url => 
                Observable.Using(
                    () => new DisposableWebRequest("http://yahoo.com"),
                    r =>
                    {
                        Trace.WriteLine("Queued " + url);
                        Trace.Flush();
                        return Observable
                            .FromAsyncPattern<WebResponse>(r.BeginGetResponse, r.EndGetResponse)();
                    });
