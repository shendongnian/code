    static void AddChildren(PivotGroup group, List<string> path)
    {
        string key = path[0];
        int index = group.ChildGroups.FindIndex(g => g.Key == key);
        PivotGroup child;
        if (index >= 0) { // A child with this key exists.
            child = group.ChildGroups[index]; // Select this existing child.
        } else { // This key is missing. Add a new child.
            child = new PivotGroup { Key = key };
            group.ChildGroups.Add(child);
        }
        if (path.Count > 1) {
            path.RemoveAt(0); // Remove the added child key and add the rest recursively.
            AddChildren(child, path);
        }
    }
