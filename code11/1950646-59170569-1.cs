    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                var item= new MyClass() { SomeProperty = "Testing" };
            
            grdData.DataContext = item;
        }
    }
    public class MyClass : IDataErrorInfo
    {
        public string SomeProperty { get; set; }
        public string this[string columnName] => "Some Specific Error";
        public string Error => "Something is wrong";
    }
