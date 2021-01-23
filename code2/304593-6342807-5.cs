    <TextBox>
        <TextBox.Text>
            <MultiBinding Converter="{StaticResource myConverter}">
                <Binding Path="FirstName"/>
                <Binding Path="LastName"/>
            </MultiBinding>
        </TextBox.Text>
    </TextBox>
	public class MyConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return values[0] + " " + values[1];
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			string[] strings = ((string)value).Split(' ');
			return strings;
		}
	}
