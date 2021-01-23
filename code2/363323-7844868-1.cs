	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			List<Customer> customers = new List<Customer>();
			for (int i = 0; i < 10; i++)
			{
				customers.Add(new Customer {FirstName = "name" + i, LastName = "last" + i});
			}
			DataContext = customers;
		}
	}
	//Defines the customer object
	public class Customer
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
