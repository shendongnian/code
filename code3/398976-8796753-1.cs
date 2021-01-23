    public static void AddError<TModel>(
        this ModelStateDictionary modelState, 
        TModel item,
        Expression<Func<TModel, object>> expression, 
        string resourceKey, 
        string defaultValue)
    {
        // TModel's instance is accessible through `item`.
    }
