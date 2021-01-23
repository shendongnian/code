    public static IObservable<WebClientResponse> DownloadStringAsync(this WebClient webClient, Uri address, WebHeaderCollection requestHeaders)
    {
        return Observable
            .Create(observer => 
            {
                DownloadStringAsyncImpl(webClient, address, requestHeaders)
                    .Subscribe(observer);
                return () => { webClient.CancelAsync(); };
            });
    }
