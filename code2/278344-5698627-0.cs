    <ListBox x:Name="List1" >
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Converter={StaticResource  NumberConverter}}" />
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
    public class NumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int[])
            {
                int[] intValues = (int[])value;
                return String.Join(",", intValues);
            }
            else return Binding.DoNothing;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
