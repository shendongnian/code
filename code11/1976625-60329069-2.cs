    IEnumerable<Node> Recurcive(List<Node> nodeList, int? parentId)
    {
        return nodeList
            .Where(x => x.ParentId == parentId)
            .SelectMany(x =>
                      new[] { new Node
                        { Id = x.Id, Name = x.Name, ParentId = x.ParentId } }
                            .Concat(Recurcive(nodeList, x.Id)));
    }
    
    foreach (var node in Recurcive(nodes, null))
        Console
         .WriteLine($"Id : {node.Id}\t, Name = {node.Name}\t, Parent = {node.ParentId}");
