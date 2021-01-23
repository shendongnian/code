    using System.Data;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Controls;
    
    namespace HowBindDataTableToDataGrid
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                simpleDataGrid.ItemsSource = LoadDataTable().AsDataView();
            }
    
            private void simpleDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                if (e.PropertyType == typeof(Person))
                {
                    MyDataGridTemplateColumn col = new MyDataGridTemplateColumn();
                    col.ColumnName = e.PropertyName;
                    col.CellTemplate = (DataTemplate)FindResource("PersonDataTemplate");
                    e.Column = col;
                    e.Column.Header = e.PropertyName;
                }
                else if (e.PropertyType == typeof(Student))
                {
                    MyDataGridTemplateColumn col = new MyDataGridTemplateColumn();
                    col.ColumnName = e.PropertyName;
                    col.CellTemplate = (DataTemplate)FindResource("StudentDataTemplate");
                    e.Column = col;
                    e.Column.Header = e.PropertyName;
                }
            }
    
            private DataTable LoadDataTable()
            {
                var _simpleDataTable = new DataTable();
    
                var person = new DataColumn("Person") { DataType = typeof(Person) };
                _simpleDataTable.Columns.Add(person);
    
                var student = new DataColumn("Student") { DataType = typeof(Student) };
                _simpleDataTable.Columns.Add(student);
    
                var dr1 = _simpleDataTable.NewRow();
                dr1[0] = new Person { PersonId = 1, PersonName = "TONY" };
                dr1[1] = new Student { StudentId = 1, StudentName = "TONY" };
                _simpleDataTable.Rows.Add(dr1);
    
                var dr2 = _simpleDataTable.NewRow();
                dr2[0] = new Person { PersonId = 2, PersonName = "MAL" };
                dr2[1] = new Student { StudentId = 2, StudentName = "MAL" };
                _simpleDataTable.Rows.Add(dr2);
    
                return _simpleDataTable;
            }
        }
    
        public class MyDataGridTemplateColumn : DataGridTemplateColumn
        {
            public string ColumnName { get; set; }
    
            protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
            {
                // The DataGridTemplateColumn uses ContentPresenter with your DataTemplate.
                ContentPresenter cp = (ContentPresenter)base.GenerateElement(cell, dataItem);
                // Reset the Binding to the specific column. The default binding is to the DataRowView.
                BindingOperations.SetBinding(cp, ContentPresenter.ContentProperty, new Binding(this.ColumnName));
                return cp;
            }
        }
    }
