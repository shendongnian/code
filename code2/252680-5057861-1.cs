    public class MultiplyFormulaStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var doubleValues = values.Cast<double>().ToArray();
    
            var leftPart = string.Join(" x ", doubleValues);
    
            var rightPart = doubleValues.Sum().ToString();
    
            var result = string.Format("{0} = {1}", leftPart, rightPart);
    
            return result;
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
----
    <TextBlock.Text>
        <MultiBinding Converter="{StaticResource MultiplyFormulaStringConverter}">
            <Binding ElementName="amount_slider" Path="Value" />
            <Binding ElementName="frequency_slider" Path="Value"/>
        </MultiBinding>
    </TextBlock.Text>
