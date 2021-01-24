    private static IEnumerable<GameObject> GetChildrenRecursive(GameObject root)
    {
        var output = new List<GameObject>();
        // iterate over direct children
        foreach (Transform child in root.transform)
        {
            // Recursion here: Get all subchilds of this child
            var childsOfchild = GetChildrenRecursive(child.gameObject);
            output.AddRange(childsOfchild);
            // add the child itslef
            output.Add(child.gameObject);
        }
        //add the root object itself
        output.Add(root);
        return output;
    }
    private static IEnumerable<GameObject> GetChildrenRecursive(IEnumerable<GameObject> rootObjects)
    {
        var output = new List<GameObject>();
        foreach (var root in rootObjects)
        {
            output.AddRange(GetChildrenRecursive(root));
        }
        // remove duplicates
        return output.Distinct().ToList();
    }
