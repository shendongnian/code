C#
//  This is not a good name, but I don't know what your semantics are. 
public bool HasBeenClicked
{
    get { return (bool)GetValue(HasBeenClickedProperty); }
    protected set { SetValue(HasBeenClickedPropertyKey, value); }
}
internal static readonly DependencyPropertyKey HasBeenClickedPropertyKey =
    DependencyProperty.RegisterReadOnly(nameof(HasBeenClicked), typeof(bool), typeof(Control1),
        new PropertyMetadata(false));
public static readonly DependencyProperty HasBeenClickedProperty = HasBeenClickedPropertyKey.DependencyProperty;
private void Button_Click(object sender, RoutedEventArgs e)
{
    HasBeenClicked = true;
}
And in the control template:
XAML
<ControlTemplate.Triggers>
    <Trigger Property="HasBeenClicked" Value="True">
        <Setter Property="GridColor" Value="DarkBlue"/>
    </Trigger>
    <Trigger Property="IsChecked" Value="True">
        <Setter Property="GridColor" Value="Black"/>
    </Trigger>
</ControlTemplate.Triggers>
