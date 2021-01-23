    public class EmptyDataTemplateConverter: IValueConverter
    {
        public DataTemplate Empty{get;set;}
        public DataTemplate NonEmpty{get;set;}
        // This converts the DateTime object to the DataTemplate to use.
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
       {
           if(IsEmpty(value))
           {
              return this.Empty;
           }
           else
           {
              return this.NonEmpty;
           }
       }
        //Your "empty/not empty" implementation here. Mine is rather... incomplete.
        private bool IsEmpty(object value)
        {
           return value!=null;
        }
        // No need to implement converting back on a one-way binding 
        public object ConvertBack(object value, Type targetType, 
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
