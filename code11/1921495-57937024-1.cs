        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            public static ObservableCollection<User> Users
            {
                get
                {
                    return new ObservableCollection<User>
                    {
                        new User {UserID = 1, Username = "user 1", IsEnabled = true},
                        new User {UserID = 2, Username = "User 2", IsEnabled =true},
                        new User {UserID = 3, Username = "Username 3", IsEnabled = true},
                        new User {UserID = 4, Username = "Username 4", IsEnabled = false}
                    };
                }
            }
            private async void BtnGetStatus_Click(object sender, RoutedEventArgs e)
            {
                Button btn = sender as Button;
                User selectedUser = btn.DataContext as User;
                if (selectedUser==null)
                {
                    return;
                }
                selectedUser.IsEnabled = false;
                selectedUser.Visibility = Visibility.Collapsed;
                await Task.Run(() => doStuffAsync(selectedUser));
                selectedUser.IsEnabled = true;
                selectedUser.Visibility = Visibility.Visible;
            }
            private async Task<bool> doStuffAsync(User user)
            {
                // Do something expensive
                await Task.Delay(10000);
                return true;
            }
        }
        public class User : INotifyPropertyChanged
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            private bool isEnabled;
            public bool IsEnabled
            {
                get { return isEnabled; }
                set { isEnabled = value; RaisePropertyChanged(); }
            }
            private Visibility visibility;
            public Visibility Visibility
            {
                get { return visibility; }
                set { visibility = value; RaisePropertyChanged(); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
