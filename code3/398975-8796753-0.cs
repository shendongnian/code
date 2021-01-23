    public static void AddError<TModel>(
        this ModelStateDictionary modelState, 
        TModel item,
        Func<TModel, object> expression, 
        string resourceKey, 
        string defaultValue)
    {
        object myPropertyValue = expression(item);
        // other code
    }
