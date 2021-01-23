    IEnumerable<IEnumerable<T>> SplitIntoSections (this IEnumerable<T> source, 
        Func<T, bool> sectionDivider)
    {
        // The items in the current group.
        IList<T> currentGroup = new List<T>();
        // Cycle through the items.
        foreach (T item in source)
        {
            // Check to see if it is a section divider, if
            // it is, then return the previous section.
            // Also, only return if there are items.
            if (sectionDivider(item) && currentGroup.Count > 0)
            {
                // Return the list.
                yield return currentGroup;
                // Reset the list.
                currentGroup = new List<T>();
            }
            // Add the item to the list.
            currentGroup.Add(item);
        }
        // If there are items in the list, yield it.
        if (currentGroup.Count > 0) yield return currentGroup;
    }
