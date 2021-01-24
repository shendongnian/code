    List<CancellationTokenSource> tokens = new List<CancellationTokenSource>();
    public List<MyObject> DataGridData { get; set; }
    public void LoadDataToDatagrid(object obj)
    {
            foreach (var token in tokens)
                token.Cancel();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            tokens.Add(tokenSource);
            var task = Task.Run(() =>
            {
                return repository.GetData();
            }, tokenSource.Token);
            try
            {
                DataGridData = await task;
            }
            finally
            {
                tokenSource.Dispose();
                tokens.Remove(tokenSource);
            }
    }
