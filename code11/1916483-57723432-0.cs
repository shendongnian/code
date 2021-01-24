    foreach (var tiffImage in tiffImageList)
    {
        if (columnIndex == columnAmount)
        {
            columnIndex = 0;
            rowIndex++;
        }
    
        Image imagePreviewItem = new Image();
        imagePreviewItem.Margin = new Thickness(20, 20, 20, 20);
        TextBlock textBlock = new TextBlock();
        textBlock.VerticalAlignment = VerticalAlignment.Top;
        textBlock.HorizontalAlignment = HorizontalAlignment.Left;
        textBlock.Margin = new Thickness(40, 40, 40, 40);
        textBlock.Text = $"{tiffImage.index.ToString()}"; // Header text
    
        RenderOptions.SetBitmapScalingMode(imagePreviewItem, BitmapScalingMode.HighQuality);
        imagePreviewItem.Name = $"Image{tiffImage.index.ToString()}";
        imagePreviewItem.Source = tiffImage.image.Thumbnail;
    
        StackPanel stackPanel = new StackPanel();
        stackPanel.Width = imagePreviewItem.Width + 50;
        stackPanel.Height = imagePreviewItem.Height + 50;
        stackPanel.Children.Add(imagePreviewItem);
    
        Border border = new Border();
        border.BorderBrush = Brushes.LightGray;
        border.BorderThickness = new Thickness(1);
        Thickness margin = border.Margin;
        border.Margin = new Thickness(20, 20, 20, 20);
        border.Child = stackPanel;
        Grid.SetColumn(border, columnIndex);
        Grid.SetRow(border, rowIndex);
    
        Grid.SetColumn(textBlock, columnIndex);
        Grid.SetRow(textBlock, rowIndex);
    
        gridPreview.Children.Add(border);
        gridPreview.Children.Add(textBlock);
    }
