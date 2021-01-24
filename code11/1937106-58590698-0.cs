    class ViewModel : INotifyPropertyChanged
    {
      // Ctor
      public ViewModel() => this.FileActionEntries = new ObservableCollection<FileActionEntry>();
      private void AddFileActionToListView()
      {
        var newFileEntry = new FileActionEntry() { NumberX = numValue, ActionX = actionValue, FileX = fileValue };
        // Add an item to the ListView
        // or any other control that binds to FileActionEntries (ObservableCollection)
        this.FileActionEntries.Add(newFileEntry);
      }
      private int CheckFileAction(string action, string file)
      {
        // Throws an exception if file not found
        FileActionEntry fileEntry = this.FileActionEntries.First(entry => entry.FileX.Equals(file, StringComparison.OrdinalIgnoreCase));
        // TODO: Check action
        // Remove an item from the ListView
        // or any other control that binds to FileActionEntries (ObservableCollection)
        this.FileActionEntries.Remove(fileEntry);
        return fileEntry.NumberX;
      }
      private ObservableCollection<FileActionEntry> fileActionEntries;
      public ObservableCollection<FileActionEntry> FileActionEntries
      {
        get => this.fileActionEntries;
        set 
        { 
          this.fileActionEntries = value; 
          OnPropertyChanged();
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
