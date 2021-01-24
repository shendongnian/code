    static void AddChildren(PivotGroup group, List<string> path)
    {
        for (int i = 0; i < path.Count; i++) {
            string key = path[i];
            int index = group.ChildGroups.FindIndex(g => g.Key == key);
            PivotGroup child;
            if (index >= 0) { // A child with this key exists.
                child = group.ChildGroups[index]; // Select this existing child.
            } else { // This key is missing. Add a new child.
                child = new PivotGroup { Key = key };
                group.ChildGroups.Add(child);
            }
            group = child;
        }
    }
