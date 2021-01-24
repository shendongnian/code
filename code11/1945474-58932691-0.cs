    <TextBlock Text="{Binding Path=Courses,Converter={StaticResource CourseToStringConverter}}" Margin="1"/>
CourseToStringConverter
[ValueConversion(typeof(List<string>), typeof(string))]
public class CourseToStringConverter: IValueConverter
{
   public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (targetType != typeof(string))
            throw new InvalidOperationException("The target must be a String");
        return "Taken Courses Are - " + String.Join(", ", ((List<string>)value).ToArray());
    }
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
