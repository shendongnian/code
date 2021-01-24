    class MainViewModel
    {
      public BaseViewModel LoginViewModel { get; set; }
      public BaseViewModel MenuViewModel { get; set; }
      public BaseViewModel OrderViewModel { get; set; }
    
      public MainViewModel()
      {
        this.LoginViewModel = new LoginViewModel();
        this.MenuViewModel = new MenuViewModel();
        this.OrderViewModel = new OrderViewModel();
    
        this.CurrentViewModel = this.LoginViewModel;
      }
    
      private void SwitchView(string name)
      {
        switch (name)
        {
          case "login":
            this.User = null;
            this.CurrentViewModel = this.LoginViewModel;
            break;
          case "menu":
            this.CurrentViewModel = this.MenuViewModel;
            break;
          case "order":
            this.CurrentViewModel = this.OrderViewModel;
            break;
        }
      }
    }
