    public class CustomEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ComboBoxEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem)
        {
            return new string[1] { CustomValueConverter.Null }
                .Concat(Enum.GetValues(typeof(YesNo)).OfType<YesNo>().Select(x => x.ToString()));
        }
        protected override IValueConverter CreateValueConverter()
        {
            return new CustomValueConverter();
        }
        protected override ComboBox CreateEditor()
        {
            ComboBox comboBox = base.CreateEditor();
            FrameworkElementFactory textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.SetBinding(TextBlock.TextProperty, new Binding(".") { Converter = new CustomValueConverter() });
            comboBox.ItemTemplate = new DataTemplate() { VisualTree = textBlock };
            return comboBox;
        }
    }
    public class CustomValueConverter : IValueConverter
    {
        internal const string Null = "Empty...";
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Null;
            return value.ToString();
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value?.ToString();
            if (s == Null)
                return null;
            return Enum.Parse(typeof(YesNo), s);
        }
    }
