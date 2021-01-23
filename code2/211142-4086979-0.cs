    private static void ExpandGroup(PropertyGrid propertyGrid, string groupName)
	{
		GridItem root = propertyGrid.SelectedGridItem;
		//Get the parent
		while (root.Parent != null)
			root = root.Parent;
		if (root != null)
		{
			foreach (GridItem g in root.GridItems)
			{
				if (g.GridItemType == GridItemType.Category && g.Label == groupName)
				{
					g.Expanded = true;
					break;
				}
			}
		}
	}
