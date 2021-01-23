    <UserControl.Resource>
       <HourToBrushConverter x:Key="hourToBrushConverter" />
    </UserControl.Resource>
    
    
    <DataGrid ItemsSource="{Binding DailyValues}" AutoGenerateColumns="False" >
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="1AM" Width="SizeToCells" IsReadOnly="True">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Rectangle Fill="{Binding . 
                                   Converter={StaticResource hourToBrushConverter}, 
                                   ConverterParameter=1}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
    <DataGridTemplateColumn Header="2AM" Width="SizeToCells" IsReadOnly="True">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Rectangle Fill="{Binding . 
                                   Converter={StaticResource hourToBrushConverter}, 
                                   ConverterParameter=2}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <!-- add a column for each hour (up to 24) -->
        </DataGrid.Columns>
    </DataGrid>
    [ValueConversion(typeof(int), typeof(Brush))]
    public class HourToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int dayValue = (int)value;
            int hourNumber = (int)parameter;
            int mask = GetMask(hourNumber);
            
            return (dayValue & mask) > 0 ? Brushes.Green : Brushes.Red;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
       
        private static int GetMask(int index)
        {
           return 1 << index;
        }
    }
