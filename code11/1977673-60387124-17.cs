    // Main view model
    class AppVM : ObservableObject     
    {
      // Create a property that controls current view
      private ObservableObject _currentView;
      public ObservableObject CurrentView
      {
        get => _currentView; 
        private set => OnPropertyChanged(ref _currentView, value);
      }
    
      private Dictionary<string, ObservableObject> Pages { get; set; }
    
      public AppVM()
      {
        // Create and store the pages, 
        // so that the same instances can be reused. 
        // All pages must extend ObservableObject (or any other common base type).
        this.Pages = new Dictionary<string, ObservableObject>()
        {
          { nameof(DefaultVM), new DefaultVM() },
          { nameof(View1VM), new View1VM() },
          { nameof(View2VM), new View2VM() },
        };    
    
        // Initialize first page
        this.CurrentView = this.Pages[nameof(DefaultVM)];
    
        this.DefaultCommand  = new RelayCommand(param => this.CurrentView = this.Pages[nameof(DefaultVM)], param => true);
        this.View1ButtonCommand = new RelayCommand(param => this.CurrentView = this.Pages[nameof(View1VM)], param => true);
        this.View2ButtonCommand = new RelayCommand(param => this.CurrentView = this.Pages[nameof(View2VM)], param => true);
      }  
    }
