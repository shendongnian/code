    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
            UpdateBinding();
        }
        private void UpdateBinding()
        {
            if (people != null && people.Count > 0)
            {
                textBlock.Text = people[0].FullInfo;
            }
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DataAccess db = new DataAccess();
            people = db.GetPeople(lastNameTB.Text);
            UpdateBinding();
        }
    }
