    [MarkupExtensionReturnType(typeof (IValueConverter))]
    public abstract class ConverterMarkupExtension<T> : MarkupExtension where T : class, IValueConverter, new()
    {
        private static T _converter;
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new T());
        }
    }
    
    public class EnumConverter<T> : ConverterMarkupExtension<EnumConverter<T>>, IValueConverter
        where T : struct
    {
        #region Implemented Interfaces
    
        #region IValueConverter
    
        /// <summary>
        ///   convert from enum to string
        /// </summary>
        /// <param name = "value"></param>
        /// <param name = "targetType"></param>
        /// <param name = "parameter"></param>
        /// <param name = "culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
    
            string convert = typeof(GlossaryResources).GetProperty(value.ToString()).GetValue(null, null).ToString();
    
            return new Item { Name = value.ToString(), Value = convert };
        }
    
        /// <summary>
        ///   convert from string to enum value
        /// </summary>
        /// <param name = "value"></param>
        /// <param name = "targetType"></param>
        /// <param name = "parameter"></param>
        /// <param name = "culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
    
            T enumvalue;
            Enum.TryParse(value.Cast<Item>().Name, out enumvalue);
            return enumvalue;
        }
    
        #endregion
    
        #endregion
    }
    
    public class GenderEnumConverter : EnumConverter<Gender>
    {
    }
