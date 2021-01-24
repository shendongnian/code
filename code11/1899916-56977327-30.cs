    public class MainViewModel : ViewModelBase
    {
      // The page viewmodels  
      private Dictionary<string, ViewModelBase> PageViewModels { get; set; }
      public Stack<string> ViewsQueue;
    
      public MainViewModel()
      {
        User = new User(1, "login", "name", "surname", 1, 1, 1);
    
        this.PageViewModels = new Dictionary<string, ViewModelBase>()
        {
          {"login", new LoginViewModel()},
          {"menu", new MenuViewModel()},
          {"order", new OrderViewModel()},
          {"clients", new ClientsViewModel(User)}
        };
    
        this.CurrentViewModel = this.PageViewModels["login"];
    
        this.ViewsQueue = new Stack<string>();
        this.ViewsQueue.Push("login");
    
        Messenger.Default.Register<NavigateTo>(
          this,
          (message) =>
          {
            try
            {
              ViewsQueue.Push(message.Name);
              if (message.user != null) User = message.user;
              SwitchView(message.Name);
            }
            catch (System.InvalidOperationException e)
            {
            }
          });
    
        Messenger.Default.Register<GoBack>(
          this,
          (message) =>
          {
            try
            {
              ViewsQueue.Pop();
              SwitchView(ViewsQueue.Peek());
            }
            catch (System.InvalidOperationException e)
            {
            }
          });
      }
    
      public RelayCommand<string> GoTo => new RelayCommand<string>(
        viewName =>
        {
          ViewsQueue.Push(viewName);
          SwitchView(viewName);
        });
    
    
      protected void SwitchView(string name)
      {
        if (this.PageViewModels.TryGetValue(name, out ViewModelBase nextPageViewModel))
        {
          if (nextPageViewModel is OrderViewModel orderViewModel)
            orderViewModel.ResetOrder();
          this.CurrentViewModel = nextPageViewModel;
        }
      }
    }
