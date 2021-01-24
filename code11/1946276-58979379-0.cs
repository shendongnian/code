<ControlTemplate ...>
    ...
    <ControlTemplate.Triggers>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="IsEnabled" Value="True" />
                <Condition Property="IsActivated" Value="True" />
            </MultiTrigger.Conditions>
            <Setter TargetName="Border" Property="Background" Value="{StaticResource ReflexBlue}" />
        </MultiTrigger>
    </ControlTemplate.Triggers>
</ControlTemplate>
However, if you don't need to keep using `MultiStateButton`, I would keep your custom button style, and control template, and use an attached property class to add the new property.
public static class MultiStateButtonProperties
{
    public static readonly DependencyProperty IsActivatedProperty = DependencyProperty.RegisterAttached("IsActivated", typeof(bool), typeof(MultiStateButtonProperties), new FrameworkPropertyMetadata(false));
    public static bool GetIsActivated(DependencyObject obj)
    {
        return (bool)obj.GetValue(IsActivatedProperty);
    }
    public static void SetIsActivated(DependencyObject obj, bool value)
    {
        obj.SetValue(IsActivatedProperty, value);
    }
}
Then, in your style's control template, you can use a MultiTrigger like the one above and do something like this:
<ControlTemplate ...>
    ...
    <ControlTemplate.Triggers>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="IsEnabled" Value="True" />
                <Condition Property="ap:MultiStateButtonProperties.IsActivated" Value="True" />
            </MultiTrigger.Conditions>
            <Setter TargetName="Border" Property="Background" Value="{StaticResource ReflexBlue}" />
        </MultiTrigger>
    </ControlTemplate.Triggers>
</ControlTemplate>
I hope this helps.
