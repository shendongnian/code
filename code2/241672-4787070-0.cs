    public partial class MyTabControl
    {
        public static readonly DependencyProperty ItemsProperty =
           DependencyProperty.Register(
           "Items",
           typeof(IEnumerable),
           typeof(MyTabControl),
           null);
        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public MyTabControl()
        {
            InitializeComponent();
            Items = tabControl.Items;
        }
    }
