     if (idiom == DeviceIdiom.Phone)
                {
                    var grid = new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                    {
                        Span = 3,
                    };
    
                    collectionViewItemsLayout.SetValue(CollectionView.ItemsLayoutProperty, grid);
                }
