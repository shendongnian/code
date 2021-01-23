    static IEnumerable<string> GetAllNames(IEnumerable<Node> nodes) {
        foreach (var node in nodes) {
            if (node.ChildNodes != null) {
                foreach (var childNode in GetAllNames(node.ChildNodes)) {
                    yield return childNode;
                }
            }
            yield return node.Name;
        }
    }
