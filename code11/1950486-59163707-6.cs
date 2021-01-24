    public ObservableCollection<ComboItem> ComboFiles { get; }
        = new ObservableCollection<ComboItem>();
    foreach (var file in Directory.GetFiles(directoryName)) 
    {
        ComboFiles.Add(new ComboItem { FileName = file });
    }
