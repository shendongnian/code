    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty MyListProperty =
            DependencyProperty.Register(
                nameof(MyList),
                typeof(IList<string>),
                typeof(MyControl));
        [TypeConverter(typeof(StringListConverter))]
        public IList<string> MyList
        {
            get { return (IList<string>)GetValue(MyListProperty); }
            set { SetValue(MyListProperty, value); }
        }
    }
    public class StringListConverter : TypeConverter
    {
        public override bool CanConvertFrom(
            ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        public override object ConvertFrom(
            ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return ((string)value).Split(
                new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
