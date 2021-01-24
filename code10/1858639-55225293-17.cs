    private static IEnumerable<GameObject> GetChildrenRecursive(GameObject root)
    {
        var output = new List<GameObject>();
        //add the root object itself
        output.Add(root);
        // iterate over direct children
        foreach (Transform child in root.transform)
        {
            // add the child itslef
            output.Add(child.gameObject);
            // Recursion here: Get all subchilds of this child
            var childsOfchild = GetChildrenRecursive(child.gameObject);
            output.AddRange(childsOfchild);
        }
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
