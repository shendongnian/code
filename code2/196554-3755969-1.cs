    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    
    public class MyControl : ListBox 
    {
        public ObservableCollection<object> InstanceItems
        {
            get { return (ObservableCollection<object>)GetValue(InstanceItemsProperty); }
            set { SetValue(InstanceItemsProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for InstanceItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InstanceItemsProperty =
            DependencyProperty.Register("InstanceItems", typeof(ObservableCollection<object>), 
            typeof(MyControl), new UIPropertyMetadata(new ObservableCollection<object>()));
    }
    
    public class MyItemsSourceConverter : IValueConverter
    {
        #region IValueConverter Members
    
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            MyControl mc = value as MyControl;
            if (mc != null)
            {
                CompositeCollection cc = new CompositeCollection();
    
                CollectionContainer container1 = new CollectionContainer();
                BindingOperations.SetBinding(container1, CollectionContainer.CollectionProperty,
                    new Binding()
                    {
                        Source = mc,
                        Path = new PropertyPath("InstanceItems")
                    });
                cc.Add(container1);
    
                CollectionContainer container2 = new CollectionContainer()
                {
                    Collection = mc.FindResource("Static_CloudItems") as Array
                };
    
                cc.Add(container2);
    
                return cc;
            }
            return null;
        }
    
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    
        #endregion
    }
