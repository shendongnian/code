xml
<Window.Resources>
    <local:TimeToStringMulti x:Key="TimeToStringMulti" />
</Window.Resources>
<TextBlock Margin="836,423,107,25" Name="txtBlockTime">
            <TextBlock.Text>
                <MultiBinding Converter="{StaticResource TimeToStringMulti}" Mode="TwoWay">
                    <Binding ElementName="sliderHours" Path="Value"/>
                    <Binding ElementName="sliderMinutes" Path="Value"/>
                </MultiBinding>
            </TextBlock.Text>
        </TextBlock>
And Converter.cs
c#
    public class TimeToStringMulti: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format("{0}:{1}", values[0], values[1] );
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            string[] param = (value as string).Split(':');
            return new Object[]{double.Parse(param[0]), double.Parse(param[1])};
        }
    }
