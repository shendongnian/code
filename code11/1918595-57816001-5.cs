    var nodeDict = nodes.ToDictionary(n => n.Id);
    foreach (var item in nodes)
    {
        MyNode parentNode = null;
        if (item.ParentId == -1 || !nodeDict.TryGetValue(item.ParentId, out parentNode)) // we don't want to look up the root node since it doesn't have a parent. you might want to add error handling if the parent node isn't found
        {
            continue;
        }
        parentNode.Nodes.Add(item);
    }
	
