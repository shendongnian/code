    public IEnumerable<Folder> GetDescendants(IEnumerable<Folder> list, int parentId)
    {
    	var result = list.Where(x => x.ParentfolderId == parentId).ToList();
    	foreach (var item in result)
    	{
    		result.AddRange(GetDescendants(list, item.Id));
    	}
    	return result;
    }
