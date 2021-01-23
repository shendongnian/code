	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Windows;
	namespace MyProject	{
		public partial class MainWindow : Window
		{
			public class Employee
			{
				public int Id { get; set; }
				public string Code { get; set; }
				public string Name { get; set; }
				public int Job { get; set; }
				public string Address { get; set; }
			}
			private ObservableCollection<Employee> _empCollection;
			public MainWindow()
			{
				InitializeComponent();
			}
			private void OnWindowLoaded(object sender, RoutedEventArgs e)
			{
				// Generate test data
				_empCollection =
					new ObservableCollection<Employee>
						{
							new Employee {Id = 234, Code = "E041", Name = "Employee1", Job = 1, Address = "..."},
							new Employee {Id = 245, Code = "E701", Name = "Employee2", Job = 3, Address = "..."},
							new Employee {Id = 728, Code = "E001", Name = "Employee3", Job = 9, Address = "..."},
							new Employee {Id = 663, Code = "E051", Name = "Employee4", Job = 7, Address = "..."},
						};
				DataContext =
					(from i in _empCollection
					select new {i.Code, i.Name, i.Address}).ToList();
			}
		}
	}
