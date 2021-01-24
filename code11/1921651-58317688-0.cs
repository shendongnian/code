    public class ServerModule : NancyModule
    {
       private NotifyIconViewModel CommandViewModel { get; }
       public ServerModule(NotifyIconViewModel commandViewModel)
       {
         this.CommandViewModel = commandViewModel;
         Post ("/Message", (args) =>
         {
           Application.Current.Dispatcher.Invoke(delegate
           {
              CommandViewModel.ShowWindowCommand.Execute (null);
           });
         }
       }
    }
