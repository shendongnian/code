    class MainViewModel : INotifyProeprtyChanged
    {
      public MainViewModel()
      {
        this.DocumentsMainPool = new ObservableCollection<IDocument>() 
        {
          new Document("First Document"), 
          new Document("Second Document")
        };
      }
    
      private ObservableCollection<IDocument> documentsMainPool;
      public ObservableCollection<IDocument> DocumentsMainPool
      {
        get => this.documentsMainPool;
        set
        {
          this.documentsMainPool = value;
          OnPropertyChanged();
        }
      }
    
      public ICommand NavigateToNextDocument => new RelayCommand(param => CycleNextDocuments());
    
      private void CycleNextDocuments()
      {
        // Only one or no document -> nothing to cycle through
        if (this.DocumentsMainPool.Count < 2)
        {
          return;
        }
    
        IDocument currentlySelectedDocument = this.DocumentsMainPool.FirstOrDefault(document => document.IsSelected);
        int currentDocumentIndex = this.DocumentsMainPool.IndexOf(currentlySelectedDocument);
    
        // If last document reached, show first again
        if (currentDocumentIndex == this.DocumentsMainPool.Count - 1)
        {
          this.DocumentsMainPool.FirstOrDefault().IsSelected = true;
          return;
        }
        
        IDocument nextDocument = this.DocumentsMainPool
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
