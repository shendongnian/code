    // Another version of writing such a converter
    public abstract class BaseConverter : MarkupExtension
    {
        protected IServiceProvider ServiceProvider { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            return this;
        }    
    }
    public class StaticResourceConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new StaticResourceExtension(value).ProvideValue(ServiceProvider);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //TODO - implement this for a two-way binding
            throw new NotImplementedException(); 
        }
    }
