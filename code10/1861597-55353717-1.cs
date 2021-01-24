<ComboBox x:Name="ComboBox" ItemsSource="{Binding ListCollection}" 
          PreviewKeyDown="UIElement_OnPreviewKeyDown" 
          PreviewMouseLeftButtonDown="ComboBox_OnPreviewMouseLeftButtonDown" 
          PreviewMouseLeftButtonUp="ComboBox_OnPreviewMouseLeftButtonUp"/>
code-behind 
private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Enter)
        e.Handled = true;
    base.OnPreviewKeyDown(e);
}
private void ComboBox_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
{
    if (ComboBox.IsDropDownOpen)
    {
        e.Handled = true;
        ComboBox.IsDropDownOpen = false;
    }
    base.OnPreviewMouseLeftButtonDown(e);
}
private void ComboBox_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
{
    if (ComboBox.IsDropDownOpen)
    {
        e.Handled = true;
    }
    base.OnPreviewMouseLeftButtonUp(e);
}
