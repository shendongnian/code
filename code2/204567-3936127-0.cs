    public IQueryable<T> Repository<T>()
        where T : class
    {
        if (typeof(T).IsInterface)
        {
            // if T is an interface then get the actual EntityObject Type by calling GetEntityType
            // so that entityType can be used to call back to this method 
            Type entityType = this.GetEntityType<T>();
            MethodInfo mi = this.GetType().GetMethod("Repository");
            // set the T in Repository<T> to be the entity type
            Type[] genericTypes = new Type[] { entityType };
            mi = mi.MakeGenericMethod(genericTypes);
            // call Repository<T>
            object result = mi.Invoke(this, new object[0]);
            return result as IQueryable<T>;
        }
        else
        {
            return this._context.CreateQuery<T>(this.GetEntitySetName<T>());
        }
    }
