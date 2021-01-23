    IEnumerable<T> Recursive(Node node)
    {
        yield return node;
        foreach (var siblingNode in Recursive(node.Sibling))
        {
            yield return siblingNode;
        }
        foreach (var childNode in Recursive(node.Child))
        {
            yield return childNode;
        }
    }
