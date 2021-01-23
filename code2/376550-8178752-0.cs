      <UserControl.Resource>
         <HourConverter x:Key="myHourConverter" />
      </UserControl.Resource>
      ...
      <MultiBinding Converter="{StaticResource myHourConverter}">
          <Binding Path="DayBinaryValue"/>
          <Binding Path="HourNumber"/>
        </MultiBinding>
    public class HourConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int dayBinaryValue = (int)values[0];
            int hourNumber = (int)values[1];
            int mask = GetMask(hourNumber);
            
            return (dayBinaryValue & mask) > 0 ? Brushes.Green ? Brushes.Red;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
             throw new NotSupportedException();
        }
        private int GetMask(int index)
        {
            return 1 << index;
        }
    }
