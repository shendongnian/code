    public static class ObservableWebClient
    {
        public static IObservable<string> DownloadStringObservable(
            this WebClient webClient, Uri uri)
        {
            return Observable.Create(observer =>
            {
                var disposable = new CompositeDisposable();
                var completedObservable = Observable.FromEvent<
                        DownloadStringCompletedEventHandler, 
                        DownloadStringCompletedEventArgs
                    >(
                        h => new DownloadStringCompletedEventHandler(h),
                        h => webClient.DownloadStringCompleted += h,
                        h => webClient.DownloadStringCompleted h= h
                    );
                disposable.Add(completedObservable
                    .SelectMany(ev =>
                    {
                        return (ev.EventArgs.Error != null)
                            ? Observable.Throw<string>(ev.EventArgs.Error)
                            : Observable.Return(ev.EventArgs.Result);
                    })
                    .Subscribe(observer));
                disposable.Add(Disposable.Create(
                    () => webClient.CancelAsync()));
               
                return disposable;
            });
        }
    }
