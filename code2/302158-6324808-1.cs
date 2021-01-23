    var webClientA = new WebClient();
    var webClientB = new WebClient();
    var webClientC = new WebClient();
    Observable.ForkJoin(
            webClientA.DownloadStringObservable(uriA),
            webClientB.DownloadStringObservable(uriB),
            webClientC.DownloadStringObservable(uriC),
        )
        .ObserveOnDispatcher()
        .Subscribe(dataArray =>
        {
            // All three have completed
            this.DataA = dataArray[0];
            this.DataB = dataArray[1];
            this.DataC = dataArray[2];
        });
