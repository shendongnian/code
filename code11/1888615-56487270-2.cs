    public ICommand RefreshCommand
    {
        get
        {
            return new Command(async () =>
            {
                await GetMessages();
                await parentViewModel.GetCounter();
            });
        }
    }
