    public IList<Group> Search(string searchString) {
    
        Children children = null;
    
        IQueryOver<Group> query = Session.QueryOver<Group>()
            .WhereRestrictionOn(x => x.Description).IsInsensitiveLike(searchString, MatchMode.Start)
            .Where(x => !x.IsDisabled)
            .JoinAlias(x => x.Children, () => children)
    			.Where(x => !x.IsDisabled)
            .OrderBy(x => x.Description).Asc;
    
        return query
            .Cacheable()
            .List();
    }
