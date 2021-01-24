csharp
private void Button5_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    var pointer = e.GetCurrentPoint(sender as Button);
    if (pointer.Properties.IsMiddleButtonPressed)
    {
        button6.Content = "Hello";
    }
}
Best regards.
