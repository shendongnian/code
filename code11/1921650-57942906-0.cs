    public class ServerModule : NancyModule
    {
       private NotifyIconViewModel CommandViewModel { get; }
       public ServerModule(NotifyIconViewModel commandViewModel)
       {
          this.CommandViewModel = commandViewModel;
          Post ("/Message", (args) =>
          {
            this.CommandViewModel.ShowWindowCommand.Execute();
          }
       }
    }
