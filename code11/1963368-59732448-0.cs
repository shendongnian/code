csharp
protected override void OnApplyTemplate()
{
    base.OnApplyTemplate();
    // ...
    RootGrid.PointerEntered += RootGrid_PointerEntered;
    RootGrid.PointerExited += RootGrid_PointerExited;
}
2. Complete state switching in event handling methods
csharp
private void RootGrid_PointerExited(object sender, PointerRoutedEventArgs e)
{
    VisualStateManager.GoToState(this, "Normal", true);
}
private void RootGrid_PointerEntered(object sender, PointerRoutedEventArgs e)
{
    VisualStateManager.GoToState(this, "PointerOver", true);
}
Best regards.
