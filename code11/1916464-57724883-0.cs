    <local:NameConverter x:Key="NameConverter"/>
    <TextBox Text="{Binding Converter={StaticResource NameConverter}, Mode=OneWay}" 
     public class NameConverter : IValueConverter
      {
          public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
          {
                return ((CustomerDate)((CollectionViewGroup)value).Items[0]).Customerdetails.Name;
          }
    
          public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
          {
                throw new NotImplementedException();
          }
      }
