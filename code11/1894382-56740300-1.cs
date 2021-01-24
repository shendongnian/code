XAML
<TextBox 
    VerticalAlignment="Top"
    TextChanged="IntegerTextBox_TextChanged"
    Text="{Binding Integer, RelativeSource={RelativeSource AncestorType=UserControl}, UpdateSourceTrigger=PropertyChanged}"
    />
A.xaml.cs
C#
private void IntegerTextBox_TextChanged(object sender, TextChangedEventArgs e)
{
    HasError = Validation.GetHasError(sender as TextBox);
}
public bool HasError
{
    get { return (bool)GetValue(HasErrorProperty); }
    protected set { SetValue(HasErrorPropertyKey, value); }
}
internal static readonly DependencyPropertyKey HasErrorPropertyKey =
    DependencyProperty.RegisterReadOnly(nameof(HasError), typeof(bool), typeof(A),
        new PropertyMetadata(false));
public static readonly DependencyProperty HasErrorProperty = 
    HasErrorPropertyKey.DependencyProperty;
public int Integer
{
    get { return (int)GetValue(IntegerProperty); }
    set { SetValue(IntegerProperty, value); }
}
public static readonly DependencyProperty IntegerProperty =
    DependencyProperty.Register(nameof(Integer), typeof(int), typeof(A),
        new PropertyMetadata(0));
MainWindow.xaml
XAML
<Window.Resources>
    <local:NotConverter x:Key="Not" />
</Window.Resources>
<Grid>
    <StackPanel>
        <local:A 
            Integer="34" 
            x:Name="MyAInstance" 
            />
        <local:B
            IsEnabled="{Binding HasError, ElementName=MyAInstance, 
                        Converter={StaticResource Not}}"
            />
    </StackPanel>
</Grid>
MainWindow.xaml.cs
C#
public class NotConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !System.Convert.ToBoolean(value);
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !System.Convert.ToBoolean(value);
    }
}
