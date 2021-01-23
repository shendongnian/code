        public static IObservable<Stream> RequestToStream(this IObservable<string> source, 
		TimeSpan timeout)
        {
            return
                from wc in source.Select(WebRequest.Create)
                from s in Observable
                    .FromAsyncPattern<WebResponse>(wc.BeginGetResponse,
                        wc.EndGetResponse)()
                    .Timeout(timeout, Observable.Empty<WebResponse>())
                    .Catch(Observable.Empty<WebResponse>())
                select s.GetResponseStream();
        }
