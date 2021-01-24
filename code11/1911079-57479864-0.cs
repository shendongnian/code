    void DoSubscribe()
    {
        PriceTicksSubject.Buffer(TimeSpan.FromMilliseconds(5000))
            .ObserveOn(NewThreadScheduler.Default)
            .Subscribe(bufferedPrices =>
            {
                SendtoClients(bufferedPrices.GroupBy(x => x.Key).Select(g => g.Last()).ToArray());
            });
    }
