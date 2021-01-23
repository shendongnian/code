    public bool Create<T>(T entity)
    where t : class, IChild
    {            
        //Is there an existing child record for the key details
        IChild child = null;
            child = Session.Query<T>()
                .Where(x => x.Date == entity.Date)
                .SingleOrDefault();
    return child.Parent != null;            
    }
