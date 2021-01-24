    //in .xaml
        <Window.Resources>
            <_classtemp:ValueToForegroundColorConverter x:Key="valueToForeground" />
        </Window.Resources>
                                    <DataGridTemplateColumn IsReadOnly="True" x:Name="stockColumn" Header="{StaticResource _stock}" Width="Auto">
                                        <DataGridTemplateColumn.CellTemplate>
                                            <DataTemplate>
                                                <Label Content="Cat" Foreground="{Binding DisplayCat , Converter={StaticResource valueToForeground}}"/>
                                            </DataTemplate>
                                        </DataGridTemplateColumn.CellTemplate>
                                    </DataGridTemplateColumn>
    
    //in .cs class _classtemp
    public class ValueToForegroundColorConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Black);
            Double doubleValue = 0.0;
            Double.TryParse(value.ToString(), out doubleValue);
            if (doubleValue = 0)
                brush = new SolidColorBrush(Colors.Blue);
            if (doubleValue = 1)
                brush = new SolidColorBrush(Colors.Red);
            return brush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
