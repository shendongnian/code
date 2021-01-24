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
            <!-- Bind to FNetPriceAfterDisc property of the viewmodel -->
            <Binding Path="FNetPriceAfterDisc" />
            <!-- To pass a literal value with a binding, assign it to Source -->
            <Binding Source="{}{0:c}" />
            <!-- 
            Bind to Culture property of the viewmodel: Should be String that returns 
            "de" for Germany, "en-GB" for UK, null for Pennsylvania and Australia. 
            If you want a fixed value, make it Source="de" or whatever, not Path="de".
            But if you want to use a constant culture value, you might be happier 
            just using the ConverterCulture parameter to an ordinary binding. 
            -->
            <Binding Path="Culture" />
        </MultiBinding>
    </TextBlock.Text>
</TextBlock>
