    public classImageUriConverter : IValueConverter
    {
        publicImageUriConverter()
        {
        }
        public objectConvert(objectvalue, TypetargetType, objectparameter, System.Globalization.CultureInfo culture)
        {
           Urisource = (Uri)value;
            return newBitmapImage(source);
        }
        public objectConvertBack(objectvalue, TypetargetType, objectparameter, System.Globalization.CultureInfo culture)
        {
            throw newNotImplementedException();
        }
     }
