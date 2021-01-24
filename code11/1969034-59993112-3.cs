    private IEnumerable<DataModel> data;
    public IEnumerable<DataModel> Data
    {
        get => data;
        set
        {
            data = value;
            NotifyOfPropertyChange(() => Data);
        }
    }
    public async Task StartScan()
    {
        DataAccess dataAccess = new DataAccess();
        Data = await dataAccess.Starter(progress, cts.Token);
    }
