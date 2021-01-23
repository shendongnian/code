    public class IntToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // Do the conversion from int to Text
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // Do the conversion from Text to int
        }
    }
    <Window x:Class="MyNamespace.Window1"
        ...
        xmlns:my="clr-namespace:MyNamespace"
        ...>
        <Window.Resources>
            <my:IntToTextConverter x:Key="converter" />
        </Window.Resources>
        <Grid>
            <TextBox Text={Binding Category1, Converter={StaticResource converter}}/>
        </Grid>
    </Window>
