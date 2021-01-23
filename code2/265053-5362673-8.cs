    public RelayCommand SaveCommand { get; set; }
    SaveCommand = new RelayCommand(OnSave);
    public void Save()
    {
        // save logic...
    }
