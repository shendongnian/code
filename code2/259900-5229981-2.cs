    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
      private UsersViewModel usersViewModel;
      private MessagesViewModel messagesViewModel;
      public UsersViewModel UsersViewModel
      {
        get { return this.usersViewModel; }
        set { this.usersViewModel = value; this.NotifyOfPropertyChanged(() => this.UsersViewModel);
      }
      public MessagesViewModel MessagesViewModel
      {
        get { return this.messagesViewModel; }
        set { this.messagesViewModel = value; this.NotifyOfPropertyChanged(() => this.MessagesViewModel);
      }
      public MainViewModel()
      {
        this.UsersViewModel = new UsersViewModel();
        this.MessagesViewModel = new MessagesViewModel();
        this.Items.Add(this.UsersViewModel);
        this.Items.Add(this.MessagesViewModel);
        // set default view
        this.ActivateItem(this.UsersViewModel);
      }
      public ShowUsers()
      {
        this.ActivateItem(this.UsersViewModel);
      }
      public ShowMessages()
      {
        this.ActivateItem(this.MessagesViewModel);    
      }
    }
