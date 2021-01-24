    public class MyConverter : BindableObject, IValueConverter
    {
        public Entry MyEntry { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var entry = MyEntry;
            Debug.WriteLine($"convert:pos:{entry?.CursorPosition}:");
            return (string)value;
        }
        ...
    }
