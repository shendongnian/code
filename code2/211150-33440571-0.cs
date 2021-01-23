    public static void ExpandItemWithInitialExpandedAttribute(this PropertyGrid propertyGrid)
    {
         foreach (GridItem item in propertyGrid.SelectedGridItem.Parent.GridItems)
         {
             ExpandItemWithInitialExpandedAttribute(propertyGrid, item);
         }
    }
