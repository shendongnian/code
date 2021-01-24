    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
            var multiBinding = new MultiBinding()
            {
                Converter = FallbackColorConverter.Instance,
                Mode = BindingMode.TwoWay,
                Bindings =
                {
                    new Binding()
                    {
                        Source = this,
                        Path = new PropertyPath(CustomForegroundBackingProperty),
                        Mode = BindingMode.TwoWay
                    },
                    new Binding()
                    {
                        Source = this,
                        Path = new PropertyPath(ForegroundProperty),
                        Mode = BindingMode.OneWay
                    },
                },
            };
            SetBinding(CustomForegroundProperty, multiBinding);
        }
        public Brush CustomForeground
        {
            get => (Brush)GetValue(CustomForegroundProperty);
            set => SetValue(CustomForegroundProperty, value);
        }
        public static readonly DependencyProperty CustomForegroundProperty =
            DependencyProperty.Register(nameof(CustomForeground), typeof(Brush), typeof(MyControl), new PropertyMetadata(null));
        private static readonly DependencyProperty CustomForegroundBackingProperty =
            DependencyProperty.Register("CustomForegroundBacking", typeof(Brush), typeof(MyControl), new PropertyMetadata(null));
        private class FallbackColorConverter : IMultiValueConverter
        {
            public static readonly FallbackColorConverter Instance = new FallbackColorConverter();
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return values[0] ?? values[1];
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                return new object[] { value };
            }
        }
    }
