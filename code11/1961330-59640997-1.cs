public class SumConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.Cast<int>()?.Sum()?.ToString();
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return null;
    }
}
And use it in XAML like this
<TextBox>
    <TextBox.Resources>
        <local:SumConverter x:Key="SumConverter"/>
    </TextBox.Resources>
    <TextBox.Text>
        <MultiBinding Converter="{StaticResource SumConverter}">
            <Binding Path="Text" ElementName="OtherTextBox1" />
            <Binding Path="Text" ElementName="OtherTextBox2" />
            <Binding Path="Text" ElementName="OtherTextBox3" />
            <Binding Path="Text" ElementName="OtherTextBox4" />
            <Binding Path="Text" ElementName="OtherTextBox5" />
        </MultiBinding>
    </TextBox.Text>
</Control>
Hope this helps
