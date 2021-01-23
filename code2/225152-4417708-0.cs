    private List<NodesEntity> ReturnHierarchyFilteredByType(List<NodesEntity> nodesEntities, List<String> nodeTypes)
    {
      List<NodesEntity> _nodesEntities = new List<NodesEntity>();
      foreach (NodesEntity _nodesEntity in nodesEntities)
      {
        //We first recurse to the bottom
        List<NodesEntity> _childNodesEntities = ReturnHierarchyFilteredByType(_nodesEntity.ChildNodes, nodeTypes);
        if (nodeTypes.Contains(_nodesEntity.Type))
        {
          //The node matches what we have in the list
          _nodesEntities.Add(_nodesEntity);
          _nodesEntity.ChildNodes = _childNodesEntities;
        }
        else
        {
          //We pull the child nodes into this level
          _nodesEntities.AddRange(_childNodesEntities);
        }
      }
      return _nodesEntities;
    }
