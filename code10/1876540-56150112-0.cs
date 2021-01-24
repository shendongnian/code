XAML
<UserControl x:Class="..."
    ...
    xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity"
    xmlns:ext="clr-namespace:NamespaceOfMyBehavior"
    ... >
    ...
        <Button...>
            <!-- The triggers looks like above -->
            <i:Interaction.Triggers>...</i:Interaction.Triggers>  
            <i:Interaction.Behaviors>
                <ext:PlcButtonBehavior PlcVar="PlcVar"/>
            </i:Interaction.Behaviors>
        </Button>
        ...
</UserControl>
The Behavior class looks like
c#
public class PlcButtonBehavior : Behavior<Button>
{
    public static readonly DependencyProperty InvalidValueProperty =
        DependencyProperty.Register(
            "InvalidValue", typeof(string), typeof(PlcButtonBehavior),
            new PropertyMetadata(string.Empty, (d, e) =>
                (PlcButtonBehavior)d).Update()));
    public string PlcVar
    {
        get { return (string)GetValue(InvalidValueProperty); }
        set { SetValue(InvalidValueProperty, value); }
    }
    protected override void OnAttached()
    {
        base.OnAttached();
        AssociatedObject.IsEnabledChanged += AssociatedObject_IsEnabledChanged;
        AssociatedObject.IsVisibleChanged += IsVisibleChanged_IsVisibleChanged;
        Update();
    }
    protected override void OnDetaching()
    {
        AssociatedObject.IsEnabledChanged -= AssociatedObject_IsEnabledChanged;
        AssociatedObject.IsVisibleChanged -= IsVisibleChanged_IsVisibleChanged;
        base.OnDetaching();
    }
    private void AssociatedObject_IsEnabledChanged(
        object sender, DependencyPropertyChangedEventArgs e)
    {
        Update();
    }
    private void IsVisibleChanged_IsVisibleChanged(
        object sender, DependencyPropertyChangedEventArgs e)
    {
        Update();
    }
    private void Update()
    {
        if (AssociatedObject is Button button
            && button.IsVisible
            && button.IsEnabled
            && AssociatedObject.IsPressed)
        {
            Plc.SetFlag(PlcVar);           
        }
        else
        {
            Plc.ResetFlag(PlcVar);             
        }
    }
}
To set the events from the behavior as a trigger it does not work.
