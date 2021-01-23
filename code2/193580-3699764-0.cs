    public partial class MainWindow : Window
    {
        public ObservableCollection<FakeEmail> Emails { get; private set; }
        public MainWindow()
        {
            Emails = new ObservableCollection<FakeEmail>();
            // simulates emails being received; you would popoulate with valid emails IRL
            Emails.Add(new FakeEmail 
                { From = "herp", Subject = "derp", Message = "herp derp" });
            Emails.Add(new FakeEmail 
                { From = "foo", Subject = "bar", Message = "foo bar" });
            Emails.Add(new FakeEmail 
                { From = "Binding", Subject = "Rocks", Message = "Binding rocks" });
            InitializeComponent();
        }
    }
    /// <summary>
    /// I don't have your libraries
    /// </summary>
    public sealed class FakeEmail
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
