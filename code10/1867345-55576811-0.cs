    public partial class MainWindow : Window
    {
    	public List<code360> Code360Manager { get; set; } = new List<code360>();
    
        public MainWindow()
        {
            InitializeComponent();
    
    		Code360Manager.Add(new code360() {firstName = "Tim", lastName = "Joy", email = "tim@joy.com", phoneNumber = "0988390243", amount = 200000 });
    
    		DataContext = this;
    	}
    
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            //studentGrid.ItemsSource = Code360Manager();
            MessageBox.Show("This is to test the firstname", firstName.Text);
        }
    }
    
    public class code360
    {
    	public string firstName { get; set; }
    	public string lastName { get; set; }
    	public string email { get; set; }
    	public string phoneNumber { get; set; }
    	public decimal amount { get; set; }
    }
