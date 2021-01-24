    public async Task StartScan()
    {
        DataAccess dataAccess = new DataAccess();
        Data = new BindableCollection<DataModel>(await dataAccess.Starter(progress, cts.Token));
    }
