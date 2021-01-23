    public class UniversalConverter : IValueConverter {
          public object Convert(object value, Type targetType, 
                             object parameter, CultureInfo culture) {
    if(_SelectedWorkOrder.DateActivated.ToShortDateString() != "1/1/0001")
    {
              return Visibility.Collapsed;
          }
    else { return Visibility.Visible;
    }
