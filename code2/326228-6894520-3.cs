    <DataGrid>
        <DataGrid.Resources>
            <TotalCostConverter x:Key="TotalCostConverter"/>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Amount" Binding="{Binding OrderAmount}"/>
            <DataGridTextColumn Header="ItemCost" Binding="{Binding ItemCost}"/>
            <DataGridTextColumn Header="Total" Binding="{Binding Converter={StaticResource TotalCostConverter}"/>
        </DataGrid.Columns>
    </DataGrid>
    //Converter
    public class TotalCostConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemOrder = value as ItemOrder;
            return itemOrder.OrderAmount * itemOrder.ItemCost;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
