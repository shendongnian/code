public partial class BusListDeviceControl : UserControl
    {
        public static readonly DependencyProperty DevicesProperty =
            DependencyProperty.Register("Devices", typeof(ObservableCollection<Device>), 
            typeof(BusListDeviceControl), new PropertyMetadata (new ObservableCollection<Device>()));
        public ObservableCollection<Device> Devices
        {
            get { return (ObservableCollection<Device>)GetValue(DevicesProperty ); }
            set
            {
                SetValue(DevicesProperty ,value);
            }
        }
        public static readonly DependencyProperty BackgroundColorProperty =
        DependencyProperty.Register("BackgroundColor", typeof(string), typeof(BusListDeviceControl));
        public string BackgroundColor
        {
            get { return (string)GetValue(BackgroundColorProperty);  }
            set
            {
                SetValue(BackgroundColorProperty,value);
            }
        }
        public BusListDeviceControl()
        {
            InitializeComponent();
        }
    }
  [1]: https://docs.microsoft.com/en-us/dotnet/framework/wpf/advanced/custom-dependency-properties#implementing-the-wrapper
