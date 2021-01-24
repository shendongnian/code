#region Command
public static DependencyProperty PreviewMouseLeftButtonUpCommandProperty = DependencyProperty.RegisterAttached(
            "PreviewMouseLeftButtonUpCommand",
            typeof(ICommand),
            typeof(AttachedCommandBehavior),
            new FrameworkPropertyMetadata(PreviewMouseLeftButtonUpChanged));
public static void SetPreviewMouseLeftButtonUpCommand(DependencyObject target, ICommand value)
{
    target.SetValue(PreviewMouseLeftButtonUpCommandProperty, value);
}
public static ICommand GetPreviewMouseLeftButtonUpCommand(DependencyObject target)
{
    return (ICommand)target.GetValue(PreviewMouseLeftButtonUpCommandProperty);
}
private static void PreviewMouseLeftButtonUpChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
{
    if (d is UIElement element)
    {
        if (e.NewValue != null && e.OldValue == null)
        {
            element.PreviewMouseLeftButtonUp += element_PreviewMouseLeftButtonUp;
        }
        else if (e.NewValue == null && e.OldValue != null)
        {
            element.PreviewMouseLeftButtonUp -= element_PreviewMouseLeftButtonUp;
        }
    }
}
private static void element_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
{
    if (sender is UIElement element)
    {
        if (element.GetValue(PreviewMouseLeftButtonUpCommandProperty) is ICommand command)
            command.Execute(CommandParameterProperty);
    }
}
#endregion
