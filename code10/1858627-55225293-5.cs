    private static IEnumerable<GameObject> GetChildrenRecursive(GameObject root)
    {
        var output = new List<GameObject>();
        // iterate over direct children
        foreach (Transform child in root.transform)
        {
            var childsOfchild = GetChildrenRecursive(child.gameObject);
            output.AddRange(childsOfchild);
            // add the children themselves
            output.Add(child.gameObject);
        }
        //add the root object itself
        output.Add(root);
        return output;
    }
    private static IEnumerable<GameObject> GetChildrenRecursive(List<GameObject> rootObjects)
    {
        var output = new List<GameObject>();
        foreach (var root in rootObjects)
        {
            output.AddRange(GetChildrenRecursive(root));
        }
        // remove duplicates
        return output.Distinct().ToList();
    }
