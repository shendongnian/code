chsarp
// Property in the View Model
public string Text { get;set; }
// Converter class
public class TrimTextConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if (!string.IsNullOrEmpty((string)value)) {
            return ((string)value).Trim();
        }
        return string.Empty;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        return value;
    }
}
 xaml
<!--In the xaml file-->
<!--Reference to the converter namespace-->
xmlns:converter="clr-namespace:namespace-where-converter-is-located"
<!--Adding Converter To Resource Dictionary-->
<ResourceDictionary>
    <converter:TrimTextConverter x:Key="TrimTextConverter"/>
</ResourceDictionary>
<!--TextBox-->
<TextBox Grid.Row="4" Text="{Binding Text, Converter={StaticResource TrimTextConverter}, UpdateSourceTrigger=PropertyChanged}">
