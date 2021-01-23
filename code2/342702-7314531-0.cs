    // enumerate all the child visuals
    List<Visual> children = new List<Visual>();
    EnumVisual(visual, children);
	// loop over each child and call GetContentBounds() on each one
    Rect? contentBounds = null;
    foreach (Visual child in children)
    {
        Rect childBounds = VisualTreeHelper.GetContentBounds(child);
        if (childBounds != Rect.Empty)
        {
            if (contentBounds.HasValue)
            {
                contentBounds.Value.Union(childBounds);
            }
            else
            {
                contentBounds = childBounds;
            }
        }
    }
    /// <summary>
    /// Enumerate all the descendants (children) of a visual object.
    /// </summary>
    /// <param name="parent">Starting visual (parent).</param>
    /// <param name="collection">Collection, into which is placed all of the descendant visuals.</param>
    public static void EnumVisual(Visual parent, List<Visual> collection)
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            // Get the child visual at specified index value.
            Visual childVisual = (Visual)VisualTreeHelper.GetChild(parent, i);
    
            // Add the child visual object to the collection.
            collection.Add(childVisual);
    
            // Recursively enumerate children of the child visual object.
            EnumVisual(childVisual, collection);
        }
    }			
