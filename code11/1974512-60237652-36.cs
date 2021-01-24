    class MainViewModel : INotifyProeprtyChanged
    {
      public MainViewModel()
      {
        this.DocumentMainPool = new ObservableCollection<IDocument>() 
        {
          new Document("First Document"), 
          new Document("Second Document")
        };
      }
    
      private ObservableCollection<IDocument> documentMainPool;
      public ObservableCollection<IDocument> DocumentMainPool
      {
        get => this.documentMainPool;
        set
        {
          this.documentMainPool = value;
          OnPropertyChanged();
        }
      }
    
      public ICommand NavigateToNextDocument => new RelayCommand(param => CycleNextDocuments());
    
      private void CycleNextDocuments()
      {
        // Only one or no document -> nothing to cycle through
        if (this.DocumentMainPool.Count < 2)
        {
          return;
        }
    
        IDocument currentlySelectedDocument = this.DocumentMainPool.FirstOrDefault(document => document.IsSelected);
        int currentDocumentIndex = this.DocumentMainPool.IndexOf(currentlySelectedDocument);
    
        // If last document reached, show first again
        if (currentDocumentIndex == this.DocumentMainPool.Count - 1)
        {
          this.DocumentMainPool.FirstOrDefault().IsSelected = true;
          return;
        }
        
        IDocument nextDocument = this.DocumentMainPool
          .Skip(currentDocumentIndex + 1)
          .Take(1)
          .FirstOrDefault();
        nextDocument.IsSelected = true;
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
