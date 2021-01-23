    public RelayCommand SaveCommand { get; set; }
    SaveCommand = new RelayCommand(OnSave, CanSave);
    public void Save()
    {
        // save logic...
    }
    public bool CanSave()
    {
        return // ... 
    }
