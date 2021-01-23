    using System.Xml.Linq;
    using System.Xml.XPath;
    public class IXPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            String xpath = (String)parameter;
            XElement element = (XElement)value;
            return element.Document.XPathSelectElement(xpath);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
