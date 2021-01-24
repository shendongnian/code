    public ObservableCollection<PLABEN> PractiListEX { get; private set; }
    PractiListEX.Clear();
    foreach (var data in this.GetPracti().OrderBy(t => t.numsec).ToList())
    {
        PractiListEX.Add(data);
    }
