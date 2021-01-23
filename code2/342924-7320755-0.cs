    public static void AddTo(this Object entity, Object parent)
    {
        parent.GetCollectionOf(entity).Add(entity);
    }
    public static dynamic And(this Object entity, Action<object> method)
    {
        method(entity);
        return entity;
    }
    dynamic entity = MakeNew(type).And(entity => entity.AddTo(parent));
