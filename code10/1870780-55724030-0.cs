    public class CollectionConverter : MarkupExtension, IValueConverter {
            public CollectionConverter() { }
    
            public override object ProvideValue(IServiceProvider serviceProvider) {
                return this;
            }
    
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                return ((ObservableCollection<Object>)value).ToList<object>();
            }
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
                return new ObservableCollection<Object>((List<object>)value);
            }
    
        }
