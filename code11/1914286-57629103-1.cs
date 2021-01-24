C#
public class CultureFormatConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, 
        CultureInfo culture)
    {
        var value = values[0];
        var format = values[1] as String;
        var targetCulture = values[2] as string;
        return string.Format(new System.Globalization.CultureInfo(targetCulture), 
            format, value);
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object 
        parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
Create the converter in Resources somewhere where it'll be in scope:
XAML
<local:CultureFormatConverter x:Key="CultureFormatConverter" />
And then use it like so:
XAML
<TextBlock>
    <TextBlock.Text>
        <MultiBinding Converter="{StaticResource CultureFormatConverter}">
            <Binding Path="FNetPriceAfterDisc" />
            <Binding Source="{}{0:c}" />
            <Binding Path="Culture" />
        </MultiBinding>
    </TextBlock.Text>
</TextBlock>
