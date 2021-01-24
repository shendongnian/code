    static PivotGroup BuildTree(string[] paths)
    {
        var root = new PivotGroup { Key = "ROOT" };
        foreach (string path in paths) {
            PivotGroup group = root;
            string[] pathElements = path.Split('!');
            for (int i = 1; i < pathElements.Length; i++) { // Element [0] is ROOT, we skip it.
                string key = pathElements[i];
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
        return root;
    }
