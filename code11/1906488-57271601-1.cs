csharp
private void Button5_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    var pointer = e.GetCurrentPoint(sender as Button);
    if (pointer.Properties.IsMiddleButtonPressed)
    {
        button6.Content = "Hello";
    }
}
## Update
Add `PointerReleased` event handler on UIElement, but not `Button`, I think Button's Click event overrides the middle mouse up event.
Usage:
csharp
private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
{
    var pointer = e.GetCurrentPoint(sender as UIElement);
    if (pointer.Properties.PointerUpdateKind == Windows.UI.Input.PointerUpdateKind.MiddleButtonReleased)
    {
        // Todo
    }
}
Best regards.
