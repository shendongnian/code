    // Main view model
    class AppVMinView1 : ObservableObject     
    {
      // Create a property that controls current view
      private ObservableObject _currentView;
      public ObservableObject CurrentView
      {
        get => _currentView; 
        private set => OnPropertyChanged(ref _currentView, value);
      }
    
      private Dictionary<string, ObservableObject> Pages { get; set; }
    
      public AppVMinView1()
      {
        // Create the pages so that the same instances can be reused. 
        // All pages must extend ObservableObject (or another common base type).
        this.Pages = new Dictionary<string, ObservableObject>()
        {
          { nameof(DefaultVM), new DefaultVM() },
          { nameof(View1VM), new View1VM() },
          { nameof(View2VM), new View2VM() },
        };
    
    
        this.CurrentView = this.Pages[nameof(DefaultVM)];
    
        this.DefaultCommand  = new RelayCommand(param => this.CurrentView = this.Pages[nameof(DefaultVM)], param => true);
        this.View1ButtonCommand = new RelayCommand(param => this.CurrentView = this.Pages[nameof(View1VM)], param => true);
        this.View1ButtonCommand = new RelayCommand(param => this.CurrentView = this.Pages[nameof(View2VM)], param => true);howDefault, AlwaysTrueCommand);
      }  
    }
