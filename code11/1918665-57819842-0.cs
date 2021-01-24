    public void RefreshView(List<TiffImage> tiffImageList)
    {
        try
        {
            if (tiffImageList.Count == 0)
                return;
            SetControlSizes(); 
            gridImageList.Children.Clear();
            gridImageList.RowDefinitions.Clear();
            gridImageList.ColumnDefinitions.Clear(); 
                    
            RowDefinitionCollection rd = gridImageList.RowDefinitions;
            ColumnDefinitionCollection cd = gridImageList.ColumnDefinitions;
    
            cd.Add(new ColumnDefinition() { Width = GridLength.Auto });
            for (int i = 0; i < tiffImageList.Count; i++)
            {
                rd.Add(new RowDefinition() { Height = GridLength.Auto });
            }
    
            int rowIndex = 0;
            foreach (var tiffImage in tiffImageList)
            {
                Image imageListViewItem = new Image();
                imageListViewItem.Margin = new Thickness(0, 0, 0, 0);
                RenderOptions.SetBitmapScalingMode(imageListViewItem, BitmapScalingMode.HighQuality);
                imageListViewItem.Name = $"Image{tiffImage.index.ToString()}"; 
                imageListViewItem.Source = tiffImage.image;
                imageListViewItem.HorizontalAlignment = HorizontalAlignment.Center;
                imageListViewItem.VerticalAlignment = VerticalAlignment.Center;
                imageListViewItem.Stretch = Stretch.Uniform;
                imageListViewItem.VerticalAlignment = VerticalAlignment.Center;
                imageListViewItem.HorizontalAlignment = HorizontalAlignment.Center;
                //  Add  HERE!!!
                imageListViewItem.LayoutTransform = new ScaleTransform();
                //
                Border border = new Border();
                border.BorderBrush = Brushes.LightGray;
                border.BorderThickness = new Thickness(1);
                Thickness margin = border.Margin;
                border.Margin = new Thickness(20, 10, 20, 10);
                border.Child = imageListViewItem;
                Grid.SetColumn(border, 0);
                Grid.SetRow(border, rowIndex);
                gridImageList.Children.Add(border);
                rowIndex++;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
