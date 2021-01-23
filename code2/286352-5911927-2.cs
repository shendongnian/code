    public class OfflineViewModel : ViewModelBase
    {
        public OfflineViewModel()
        {
            CustomCommands.AdminCommand.Delegate(ShowAdmin);
        }
        public override void Removed()
        {
            base.Removed();
            ReleaseAdminCommand();
        }
        public override void Hidden()
        {
            base.Hidden();
            ReleaseAdminCommand();
        }
        void HookAdminCommand()
        {
            CustomCommands.AdminCommand.Delegate(ShowAdmin);
        }
        void ReleaseAdminCommand()
        {
            // Remove handling
            CustomCommands.AdminCommand.Delegate(null, null);
        }
        void ShowAdmin(object parameter)
        {
            Navigation.Push(new AdminViewModel());
        }
    }
