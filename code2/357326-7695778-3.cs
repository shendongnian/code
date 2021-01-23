    public partial class MainWindow : Window
    {
        public static Users userslist = new Users();
        DispatcherTimer timer = new DispatcherTimer();
    
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }
    
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = DateTime.Now.AddSeconds(10) - DateTime.Now;
            timer.Tick += new EventHandler(timer_Tick);
            UserList.ItemsSource = userslist;
        }
    
        void timer_Tick(object sender, EventArgs e)
        {
            userslist.Add(new User("Jamy - " + userslist.Count, "James Smith", userslist.Count));
            userslist.Add(new User("Mairy - " + userslist.Count, "Mary Hayes", userslist.Count));
            userslist.Add(new User("Dairy - " + userslist.Count, "Dary Wills", userslist.Count));
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (button1.Content.ToString() == "Start")
            {
                button1.Content = "Stop";
                timer.Start();
            }
            else
            {
                button1.Content = "Start";
                timer.Stop();
            }
        }
    
    }
