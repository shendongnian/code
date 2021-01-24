csharp
public class TrimConverter : DependencyObject, IValueConverter
{
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TrimConverter), new PropertyMetadata(""));
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        bool isTrim = System.Convert.ToBoolean(value);
        return isTrim ? Text : null;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
**Usage**
xml
<Page.Resources>
    <local:TrimConverter x:Key="TrimConverter" Text="{Binding ElementName=TestBlock,Path=Text}"/>
</Page.Resources>
<Grid>
    <TextBlock TextTrimming="CharacterEllipsis"
               x:Name="TestBlock"
               ToolTipService.ToolTip="{Binding ElementName=TestBlock, 
                                                Path=IsTextTrimmed,
                                                Converter={StaticResource TrimConverter}}"/>
</Grid>
This should solve your problem.
Best regards.
