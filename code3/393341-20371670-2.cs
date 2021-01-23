    public class ArrayStringToEnumDescriptionConverter : BaseEnumDescriptionConverter, IValueConverter
    {
        public ArrayStringToEnumDescriptionConverter()
        {
            
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = value.GetType();
            return !type.IsEnum ? null : base.GetEnumDescription(type);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public abstract class BaseEnumDescriptionConverter : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public IEnumerable<string> GetEnumDescription(Type destinationType)
        {
            var enumType = destinationType;
            var values = RetrieveEnumDescriptionValues(enumType);
            return new List<string>(values);
        }
        public object GetEnumFromDescription(string descToDecipher, Type destinationType)
        {
            var type = destinationType;
            if (!type.IsEnum) throw new InvalidOperationException();
            var staticFields = type.GetFields().Where(fld => fld.IsStatic);
            foreach (var field in staticFields)
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == descToDecipher)
                    {
                        return (Enum.Parse(type, field.Name, true));
                    }
                }
                else
                {
                    if (field.Name == descToDecipher)
                        return field.GetValue(null);
                }
            }
            throw new ArgumentException("Description is not found in enum list.");
        }
        public static string[] RetrieveEnumDescriptionValues(Type typeOfEnum)
        {
            var values = Enum.GetValues(typeOfEnum);
            return (from object fieldInfo in values select DescriptionAttr(fieldInfo)).ToArray();
        }
        
        public static string DescriptionAttr(object enumToQuery)
        {
            FieldInfo fi = enumToQuery.GetType().GetField(enumToQuery.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumToQuery.ToString();
        }
        public static string GetDomainNameAttribute(object enumToQuery)
        {
            FieldInfo fi = enumToQuery.GetType().GetField(enumToQuery.ToString());
            DomainNameAttribute[] attributes = (DomainNameAttribute[])fi.GetCustomAttributes(
                typeof(DomainNameAttribute), false);
            return attributes.Length > 0 ? attributes[0].DomainName : enumToQuery.ToString();
        }
    }
    public class DescriptionToEnumConverter : BaseEnumDescriptionConverter, IValueConverter
    {
        public DescriptionToEnumConverter(){}
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var enumValue = value;
            if (enumValue != null)
            {
                enumValue = GetEnumFromDescription(value.ToString(), targetType);
            }
            return enumValue;
        }
    }
