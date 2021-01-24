    public partial class Test: UserControl
    {
        public Test()
        {
            InitializeComponent();
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModel)?.ClsTabs.Add(new Tab("New", new List<string[]>() { new string[] { "Name", "Something" }, new string[] { "Detail", "No" } }));
        }
    }
