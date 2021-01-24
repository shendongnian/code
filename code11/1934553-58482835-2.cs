    public class MainPageViewModel
    {
        public ObservableCollection<User> UserSource { get; } = new ObservableCollection<User>();     
        public MainPageViewModel()
        {
            LoadData();        
        }
    
        private async void LoadData()
        {
            UserSource.Clear();
            var users = await sqlService.AllUsers();
            if (users != null)
            {
                foreach (var item in users)
                {
                    UserSource.Add(item);
                }
            }
        }
    
        public ICommand BtnClickCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    UserSource.RemoveAt(0);
                });
            }
        }
    
    }
