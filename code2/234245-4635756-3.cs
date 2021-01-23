    public partial class Window1 : Window,INotifyPropertyChanged
    {
        public Window1()
        {
            InitializeComponent();
            DataContext = this;
        }
        private string userName;
        public string Username
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //Your code
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password));
           
        }
    }
