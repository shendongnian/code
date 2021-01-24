    public IList<QuestionGroupTree> FlatToHierarchy(IEnumerable<QuestionGroupTree> list, string parentId, string parentIndex)
    {
        var prefix = string.IsNullOrWhiteSpace(parrentIndex) ? "" : parrentIndex+".";
        return list.Where(i => i.CParentId == parentId)
            .Select((v, i) => new QuestionGroupTree {
            CNodeId = v.CNodeId, 
            CParentId = v.CParentId,
            CNodeName = v.CNodeName,
            Children = FlatToHierarchy(list, v.CNodeId, prefix+(index + 1)),
            NodeIndex = prefix+(index + 1)
        }).ToList();
    }
