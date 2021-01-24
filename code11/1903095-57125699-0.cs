    private void OnSelectedMostRecentFileChanged()
    {
      // Move the selected item to the front of the list
      this.MostRecentFiles.Move(this.MostRecentFiles.IndexOf(this.SelectedRecentFile), 0);
    }
      
    private string _selectedRecentFile;
    public string SelectedRecentFile
    {
        get { return _selectedRecentFile; }
        set
        {
            _selectedRecentFile= value;
            OnSelectedMostRecentFileChanged();
            OnPropertyChanged(nameof(SelectedRecentFile));
        }
    }
    
    private ObservableCollection<string> _mostRecentFiles = new ObservableCollection<string>();
    public ObservableCollection<string> MostRecentFiles
    {
        get { return _mostRecentFiles; }
        set
        {
            _mostRecentFiles = value;
            OnPropertyChanged(nameof(MostRecentFiles));
        }
    }
