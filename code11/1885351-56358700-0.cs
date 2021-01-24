xaml
<ComboBox ItemsSource="{Binding Example}">
    <ComboBox.ItemTemplate>
        <DataTemplate DataType="{x:Type List}">
            <!--no Path is specified, which is equivalent to Path="."-->
            <TextBlock Text="{Binding Converter={StaticResource MyConv}}"></TextBlock>
        </DataTemplate>
    </ComboBox.ItemTemplate>
</ComboBox>
And the converter used to access the Producer property:
csharp
public class MyConv : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // here value will be an item of Example list, so a List<ArticlesStock>
        var val = value as List<ArticlesStock>;
        return val[0].Producer;
    }
}
Note that I simplified your model structure for brevity.
