    namespace WpfApp1
    {
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ComboBox1.ItemsSource = Services;
            ServiceSectionModel test = new ServiceSectionModel();
            test.Color = Brushes.Red;
            test.ID = "MBT";
            test.Name = "Golan";
            Services.Add(test);
        }
        public class ServiceSectionModel
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public SolidColorBrush Color { get; set; }
        }
        ObservableCollection<ServiceSectionModel> Services = new ObservableCollection<ServiceSectionModel>();
    }
