    Dictionary<node, IEnumerable<Entity>> _nodeResults; // somewhere
    foreach (var node in selectedNodes)
    {
        if (!_nodeResults.ContainsKey(node))
            _nodeResults.Add(node, Session.Query<Entity>().Where(...).Future<Entity>());
        results = results.Concat(_nodeResults[node]);
    }
