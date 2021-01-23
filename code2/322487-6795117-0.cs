    [Import(RequiredCreationPolicy = CreationPolicy.Shared)]
    public IBusyWatcher Busy { get; set; }
    
    private IEnumerable<IResult> LoadData()
    {
        using (Busy.GetTicket())
        {
         ...
        }
    }
