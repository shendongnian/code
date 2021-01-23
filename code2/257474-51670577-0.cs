    public void IteratePropertyGrid()
    {
        GridItemCollection categories;
        if (grid.SelectedGridItem.GridItemType == GridItemType.Category)
        {
            categories = grid.SelectedGridItem.Parent.GridItems;
        }
        else
        {
            categories = grid.SelectedGridItem.Parent.Parent.GridItems;
        }
        foreach (var category in categories)
        {
            if (((GridItem)category).GridItemType == GridItemType.Category)
            {
                foreach (GridItem gi in ((GridItem)category).GridItems)
                {
                    // Do something with gi                         
                }
            }
        }
    }
