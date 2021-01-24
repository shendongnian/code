    <DataGrid ItemsSource="{StaticResource Items}" PreviewKeyDown="UIElement_OnPreviewKeyDown"/>
    private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab &&
                (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && sender is TabItem)
            {
                e.Handled = true;
            }
        }
