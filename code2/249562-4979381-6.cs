    public partial class MainWindow: Window
    {
            public class DataObject
            {
                public int A { get; set; }
                public int B { get; set; }
                public int C { get; set; }
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                var list = new ObservableCollection<DataObject>();
                list.Add(new DataObject() { A = 6, B = 7, C = 5 });
                list.Add(new DataObject() { A = 5, B = 8, C = 4 });
                list.Add(new DataObject() { A = 4, B = 3, C = 0 });
                this.dataGrid1.ItemsSource = list;
    }
