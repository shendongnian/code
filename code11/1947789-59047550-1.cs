    private async void Smashtimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        ...
        var result = await wc.ProcessPostURL(BASEURL, client, ct)
        Dispatcher.Invoke(() => AwesomeSauce.Add(result));
    }
