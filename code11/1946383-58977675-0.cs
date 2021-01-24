    <TextBlock Text="{Binding Name, Mode=TwoWay}" Grid.Column="1">
        <TextBlock.Resources>
            <local:Converter x:Key="conv" />
        </TextBlock.Resources>
        <TextBlock.ToolTip>
            <Image VerticalAlignment="Top"
                   Source="{Binding Name, Converter={StaticResource conv}, ConverterParameter='{}Images/Doc/{0}.png'}" />
        </TextBlock.ToolTip>
    </TextBlock>
----------
    public class Conveter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string name = value as string;
            string path = parameter as string;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(path))
                return new BitmapImage(new Uri(string.Format(path, name), UriKind.Relative));
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
