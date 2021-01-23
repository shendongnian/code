    Group group = null;
    var childCrit = QueryOver.Of<ChildType>()
            .Where(c => c.Group == group).And(c => c.IsDisabled)
            .Select(c => c.Id);
    var query = Session.QueryOver(() => group)
            .WhereRestrictionOn(x => x.Description).IsInsensitiveLike(searchString, MatchMode.Start)
            .Where(x => !x.IsDisabled)
            .WithSubquery.WhereNotExists(childCrit)
            .OrderBy(x => x.Description).Asc
            .Fetch(group => group.Children).Eager;
