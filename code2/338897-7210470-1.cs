    class ExportRegulationTypeToStringConverter: IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ExportRegulationType regType = (ExportRegulationType)value;
            switch(regType)
            {
                case ExportRegulationType.EAR:
                    return "EAR";
                case ExportRegulationType.DoNotExport:
                    return "Do Not Export";
                
                //handle other cases
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter,    System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
        #endregion
    }
