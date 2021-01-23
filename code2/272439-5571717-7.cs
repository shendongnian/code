    using System.Collections.ObjectModel;
    using System.Windows;
    namespace CellSelection
    {
        public partial class MainWindow : Window
        {
            /// <summary>
            /// The DataGrid will be bound to this collection
            /// </summary>
            private ObservableCollection<Employee> _collection;
            public MainWindow()
            {
                InitializeComponent();
                // Initialize the employees collection with some test data
                _collection =
                    new ObservableCollection<Employee>
                        {
                            new Employee {Id = 1, Name = "Mohammed A. Fadil", Address = "..."},
                            new Employee {Id = 485, Name = "Khalid Zein", Address = "..."},
                            new Employee {Id = 64, Name = "Ahmed Mubarak", Address = "..."},
                            new Employee {Id = 364, Name = "Ali Ebraheim", Address = "..."},
                        };
                DataContext = _collection;
            }
            private void OnExportButtonClick(object sender, RoutedEventArgs e)
            {
                // Now, concatinate all the selected cells
                var str = string.Empty;
                foreach (var emp in _collection)
                {
                    if (emp.IsIdSelected)
                        str += string.Format("{0}, ", emp.Id);
                    if (emp.IsNameSelected)
                        str += string.Format("{0}, ", emp.Name);
                    if (emp.IsAddressSelected)
                        str += string.Format("{0}", emp.Address);
                    str += "\n";
                }
                // Instead of displaying this message you could export these cells to Excel
                // in the format you need.
                MessageBox.Show(str);
            }
        }
    }
