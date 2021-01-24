    class MainViewModel
    {
      // The page viewmodels  
      private Dictionary<string, BaseViewModel> PageViewViewModels { get; set; }
    
      public MainViewModel()
      {
        this.PageViewViewModels = new Dictionary<string, BaseViewModel>() 
        {
          { "login", new LoginViewModel() },
          { "menu", new MenuViewModel() },
          { "order", new OrderViewModel() },
        };
    
        this.CurrentViewModel = this.PageViewViewModels["login"];
      }
    
      private void SwitchView(string name)
      {        
        if (this.PageViewViewModels.TryGetValue(name, out BaseViewModel nextPageViewModel))
        {
          this.CurrentViewModel = nextPageViewModel;
        }
      }
    }
