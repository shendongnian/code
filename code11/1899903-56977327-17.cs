    class MainViewModel
    {
      // The page viewmodels  
      private Dictionary<string, BaseViewModel> PageViewModels { get; set; }
    
      public MainViewModel()
      {
        this.PageViewModels = new Dictionary<string, BaseViewModel>() 
        {
          { "login", new LoginViewModel() },
          { "menu", new MenuViewModel() },
          { "order", new OrderViewModel() },
        };
    
        this.CurrentViewModel = this.PageViewModels["login"];
      }
    
      private void SwitchView(string name)
      {        
        if (this.PageViewModels.TryGetValue(name, out BaseViewModel nextPageViewModel))
        {
          this.CurrentViewModel = nextPageViewModel;
        }
      }
    }
