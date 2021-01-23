    public IQueryable<T> Query<T>(Expression<Func<T, bool>> filter)
    {
        return context.GetTable<T>().Where(filter);
    }
    
    public virtual void Update<T>(T entity)
    {
        context.GetTable<T>().Attach(entity);        
    }
    var user=something.Query<User>(x=>x.Name=="bla bla").First;
    user.Name="alb alb";
    something.Update(user);
