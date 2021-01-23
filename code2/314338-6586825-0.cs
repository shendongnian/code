    public class MyXDocumentTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof (string));
        }
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                MyXDocument d = new MyXDocument();
                d.Add(XDocument.Load(new StringReader((string) value)).Elements().First());
                return d;
            }
            return null;
        }
    }
