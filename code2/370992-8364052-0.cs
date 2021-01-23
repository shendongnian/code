    public void LoadEntityList<T>(T selectedEntity, System.Linq.Expressions.Expression<Func<T, ObjectWrapper<object>>> selector,System.Linq.Expressions.Expression<Func<T,bool>> where = null) where T : FlexyBook.Infrastructure.Entity
    {
        var wCollection = new ObjectWrapperCollection<object>();
        IQueryable<T> query = FlexyBook.Repository.DomainService<T>.GetDomainService().GetAll();
        if (where != null)
            query = query.Where(where);
        foreach (var item in query.Select(selector).ToList().OrderBy(x => x.Text))
        {
            wCollection.List.Add(item);
        }
    }
