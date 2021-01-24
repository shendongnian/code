    namespace zzWpfApp1
    {
        public partial class MainWindow : Window
        {
            public ObservableCollection<User> Users { get; set; }
            public MainWindow()
            {
                //Sample of different users
                List<User> users = new List<User>();
                users.Add(new User() { Name = "Donald Duck", ReaderType = ReaderType.Chief });
                users.Add(new User() { Name = "Mimmi Mouse", ReaderType = ReaderType.Staff });
                users.Add(new User() { Name = "Goofy", ReaderType = ReaderType.Officer });
                Users = new ObservableCollection<User>(users);
                	
                InitializeComponent();
                DataContext = this;
            }
         }
    } 
