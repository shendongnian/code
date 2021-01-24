public class NumerRow : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        DataGridRow row = values[0] as DataGridRow;
        if (row.DataContext?.GetType().FullName == "MS.Internal.NamedObject") return null;
        return (row.GetIndex() + 1).ToString();
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
And in `.xalm`
<DataGridTextColumn Header="№">
    <DataGridTextColumn.Binding>
        <MultiBinding Converter="{StaticResource NumerRow}">
            <Binding Mode="OneWay" RelativeSource="{RelativeSource AncestorType={x:Type DataGridRow}}"/>
            <Binding Mode="OneWay" RelativeSource="{RelativeSource AncestorType={x:Type DataGrid}}" Path="Items.Count"/>
        </MultiBinding>
    </DataGridTextColumn.Binding>
</DataGridTextColumn>
Result is
[![введите сюда описание изображения][1]][1]
  [1]: https://i.stack.imgur.com/rciLe.gif
