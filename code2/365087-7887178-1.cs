    private IEnumerable<long> GetChildrenIds(IEnumerable<Channel> channels, long parentId)
    {
        if(channels == null)
            throw new ArgumentNullException("channels");
        
        var childs = channels.Where(c => c.ParentId == parentId)
                             .Select(c => c.Id);
        return childs;
    }
