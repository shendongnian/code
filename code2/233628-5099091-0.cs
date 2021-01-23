    public IPagedList<Client> Find(int pageIndex, int pageSize)
    {
        Client clientAlias = null;
    
        var query = Session.QueryOver<Client>(() => clientAlias)
            
            .Select(
                Projections.Distinct(
                    Projections.ProjectionList()
                        .Add(Projections.Property<Client>(x => x.Id).As("Id"))
                        .Add(Projections.Property<Client>(x => x.Name).As("Name"))
                        .Add(Projections.Property<Client>(x => x.Surname).As("Surname"))
                        .Add(Projections.Property<Client>(x => x.GivenName).As("GivenName"))
                        .Add(Projections.Property<Client>(x => x.EmailAddress).As("EmailAddress"))
                        .Add(Projections.Property<Client>(x => x.MobilePhone).As("MobilePhone"))
                )
            )
            .TransformUsing(Transformers.AliasToBean<Client>())
    
            .OrderBy(() => clientAlias.Surname).Asc
            .ThenBy(() => clientAlias.GivenName).Asc;
    
        var count = query
            .ToRowCountQuery()
            .FutureValue<int>();
    
        return query
            .Take(pageSize)
            .Skip(Pagination.FirstResult(pageIndex, pageSize))
            .List<Client>()
            .ToPagedList(pageIndex, pageSize, count.Value);
    }
