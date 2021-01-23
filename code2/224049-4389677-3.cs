    private void TextBlock_IsMouseDirectlyOverChanged(object sender, e)
    {
        bool isMouseOver = (bool)e.NewValue;
        if (!isMouseOver)
            return;
        TextBlock textBlock = (TextBlock)sender;
        bool needed = textBlock.ActualWidth > 
            (this.listView.View as GridView).Columns[2].ActualWidth;
        ((ToolTip)textBlock.ToolTip).Visibility = 
            needed ? Visibility.Visible : Visibility.Collapsed;
    }
