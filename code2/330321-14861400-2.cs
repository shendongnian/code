        using System.Collections.Generic;
        using System.Linq;
        using System.Windows;
        using System.Windows.Data;
        
        namespace ListCollectionViewTest
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                private List<Employee> equivalentOfDatabase = new List<Employee>()
                            {
                                new Employee() { FirstName = "John", LastName = "Doe", IsWorthyOfAttention = true },
                                new Employee() { FirstName = "Jane", LastName = "Doe", IsWorthyOfAttention = true },
                                new Employee() { FirstName = "Mr.", LastName = "Unsignificant", IsWorthyOfAttention = false },
                            };
                
                public ListCollectionView TestList { get; set; }
                public MainWindow()
                {
                    DataContext = this;
                    // This is all the magic you need -------
                    TestList = new ListCollectionView(equivalentOfDatabase);
                    TestList.Filter = x => (x as Employee).IsWorthyOfAttention;
        
                    InitializeComponent();
                }
        
                private void Button_Click(object sender, RoutedEventArgs e)
                {
                    MessageBox.Show(equivalentOfDatabase.Aggregate("Employees are: \n\r", (acc, emp) => acc + string.Format("    - {0} {1}\n\r", emp.FirstName, emp.LastName), x => x));
                }
            }
        
            public class Employee
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public bool IsWorthyOfAttention { get; set; }
            }
        }
