    public class UserListViewModel : ISearchProvider
    {
        private IUserFinder userFinder;
        public UserListViewModel(IUserFinder userFinder)
        {
            this.userFinder = userFinder;
        }
        public ObservableCollection<UserViewModel> Users { get; private set; }
   
        public void Search(string criteria)
        {
            var users = this.userFinder.Search(criteria);
            // rebuild users collection - view will get notified of any changes
            // made to .Users property as it is ObservableCollection
        }
    }
