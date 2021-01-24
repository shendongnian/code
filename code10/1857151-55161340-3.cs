    // Flatten the dictionary into a set of tuples
    // e.g. (a, Red), (a, Yellow), (b, Blue), (b, Red), etc
    var result = dict.SelectMany(kvp => kvp.Value.Select(color => (key: kvp.Key, color)))
        // Group by the value, taking the color as the elements of the group
        // e.g. (Red, (a, b)), (Yellow, (a)), etc
        .GroupBy(item => item.color, item => item.key)
        // Filter to the ones with more than one item
        .Where(group => group.Count() > 1)
        // Turn it into a dictionary, taking the key of the grouping
        // (Red, Green, etc), as the dictionary key
        .ToDictionary(group => group.Key, group => group.ToList());
