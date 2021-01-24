    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MyMainDataClass();
        }
    }
    public class MySubDataClass
    {
        public string SomeValue { get; set; }
    }
    public class MyMainDataClass
    {
        public string SomeTextProperty { get; set; }
        public ObservableCollection<MySubDataClass> SubDataClasses { get; set; }
        public MyMainDataClass()
        {
            SomeTextProperty = "test";
            SubDataClasses = new ObservableCollection<MySubDataClass>();
            SubDataClasses.Add(new MySubDataClass() { SomeValue = "test1" });
            SubDataClasses.Add(new MySubDataClass() { SomeValue = "test2" });
        }
    }
