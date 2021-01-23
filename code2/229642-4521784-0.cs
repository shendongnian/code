    [ValueConversion(typeof(object), typeof(string))]
    public class RouteDifficultyNameConverter : IValueConverter
    {
        private readonly IMyMethodProvider provider;
        public RouteDifficultyNameConverter(IMyMethodProvider provider)
        {
            this.provider = provider;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return provider.GetDifficultyName((int)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
