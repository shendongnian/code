    //No more warning CS4014 since it's async void
    public async void Refresh()
    {
          await RefreshAsync();
    }
    public async Task RefreshAsync()
    {
          //code you actually want
    }
