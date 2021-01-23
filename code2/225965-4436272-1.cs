    public bool AreAllValuesUnique()
    {
        // Build up a linq expression of all of the ListItems
        // by concatenating each sequence
        var allItems = lbFullAccess.Items.Cast<ListItem>()
            .Concat(lbContributor.Items.Cast<ListItem>())
            .Concat(lbReadOnly.Items.Cast<ListItem>());
    
        // Group the previous linq expression by value (so they will be in groups of "A", "B", etc)
        var groupedByValue = allItems.GroupBy(i => i.Value);
        // Finally, return that all groups must have a count of only one element
        // So each value can only appear once
        return groupedByValue.All(g => g.Count() == 1);
    }
