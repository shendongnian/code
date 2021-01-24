    internal async Task OnBrowserNavigating(object sender, WebNavigatingEventArgs e)
    {
        Loading = true;
        if (!(sender is WebView browser))
        {
            Loading = false;
            throw new Exception($"Sender is not of type WebView");
        }
        if (!Uri.TryCreate(e.Url, UriKind.Absolute, out Uri uri))
        {
            Loading = false;
            throw new Exception($"Uri creation failed for: {e.Url}");
        }
        if (string.IsNullOrEmpty(_options.EndUrl) == false)  //IF THE CONDITION OVER HERE & FOR INNER IF CONDITIONS FAILS, LOADER WASNT SET TO FALSE 
        {
            if (uri.AbsoluteUri.StartsWith(_options.EndUrl))
            {
                _result = new BrowserResult() { ResultType = BrowserResultType.Success, Response = uri.Fragment.Substring(1) };
                e.Cancel = true;
                if (!_navPopped)
                {
                    _navPopped = true;
                    Loading = false;
                    await PopPageModel();
                }
            }
        }
        Loading = false;
    }
