    [TypeConverter(typeof(BitmapFilenameConverter))]
    public class BitmapFilename {...}
    class BitmapFilenameConverter : TypeConverter {
        public override object ConvertFrom(ITypeDescriptorContext context,
            CultureInfo culture, object value)
        {
            string s = value as string;
            if(s != null) {
                  /***** YOUR CODE HERE ******/
            } else {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
