using System.Windows.Data;
public class ExampleToUpperConverter : IValueConverter
{
    //Converts input string and returns new formatted string
    //Input string is your bound "ExampleString" value in your case
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        //Get the header string value
        var str = value as string;
        
        //Handle null values
        if(string.IsNullOrEmpty(str)){return string.Empty;}
        return string.Format("ExampleHeader: {0}",str.ToUpper());
    }
    
    //Converts formatted string back to original value
    //Only applicable on input controls, but the method is still required in the class
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}
Ok now that it's built you must declare the converter as a resource in your XAML. You may have a dictionary somewhere. For this example I'm going to put in in your `MainWindow.xaml` and assume your control is also used in your `MainWindow`
<Window.Resources>
    <local: ExampleToUpperConverter x:Key="ExampleToUpperConverter"/>
</Window.Resources>
Now you can tap into the `IValueConverter` whenever needed.
<DataGridTextColumn Header="{Binding ExampleString, Converter={StaticResource ExampleToUpperConverter}}" />
