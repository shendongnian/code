    //No more warning CS4014 since it's async void
    public async void Refresh()
    {
          await Refresh1();
    }
    public async Task Refresh1()
    {
          //code you actually want
    }
