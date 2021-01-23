    public partial class MainWindow: Window
    {
            public class DataObject
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public DateTime DateOfBirth { get; set; }
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                var list = new ObservableCollection<DataObject>();
                list.Add(new DataObject() 
                   { FirstName = "Test", LastName = "Name", DateOfBirth = DateTime.Now });
                list.Add(new DataObject());
                list.Add(new DataObject());
                this.dataGrid1.ItemsSource = list;
    }
