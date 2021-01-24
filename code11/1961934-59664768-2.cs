    public class NameConverter : IValueConverter
    {
    
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        Contact contact = (Contact)value;
        return $"{contact.FirstName} {contact.LastName}";
      }
    
        ...
    }
