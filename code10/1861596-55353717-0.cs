<ComboBox x:Name="ComboBox" ItemsSource="{Binding ListCollection}" PreviewMouseDown="UIElement_OnPreviewMouseDown" PreviewKeyDown="UIElement_OnPreviewKeyDown"/>
code-behind 
private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
{
    if (ComboBox.IsDropDownOpen)
        e.Handled = true;
    base.OnPreviewMouseDown(e);
}
private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Enter)
        e.Handled = true;
    base.OnPreviewKeyDown(e);
}
