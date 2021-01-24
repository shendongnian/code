    [ValueConversion(typeof(UserViewModel), typeof(string))]
    public class UsernameFormatConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        if (value is UserViewModel user)
        {
          return string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.FirstName)
            ? user.Username
            : user.FirstName + " " + user.LastName + " (You)";
        }
    
        return Binding.DoNothing;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotSupportedException();
      }
    }
