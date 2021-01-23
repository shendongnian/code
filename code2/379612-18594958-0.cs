    public void NavigateSynchronously(string url)
    {
        this.WbrConfigurator.Navigate(url);
        while (this.WbrConfigurator.ReadyState != WebBrowserReadyState.Complete)
        {
            Application.DoEvents();
            Thread.Sleep(100);
        }
    }
