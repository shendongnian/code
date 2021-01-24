    public partial class SvgIcon : UserControl
    {
        public SvgIcon()
        {
            InitializeComponent();
        }
        public Geometry Data
        {
            get { return (Geometry) GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
        public Stretch Stretch
        {
            get { return (Stretch) GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }
        public static readonly DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(Geometry), typeof(SvgIcon));
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(SvgIcon));
    }
