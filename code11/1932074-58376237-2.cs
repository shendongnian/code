    namespace WpfApp1
    {
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ComboBox1.ItemsSource = Services;
            Services.Add(new ServiceSectionModel { Color = Brushes.Red, ID = "Clem", Name = "Clementine" });
            Services.Add(new ServiceSectionModel { Color = Brushes.White, ID = "011", Name = "Logistique" });
            Services.Add(new ServiceSectionModel { Color = Brushes.Green, ID = "MBT", Name = "Montbrilland" });
        }
        public class ServiceSectionModel
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public SolidColorBrush Color { get; set; }
        }
        ObservableCollection<ServiceSectionModel> Services = new ObservableCollection<ServiceSectionModel>();
    }
