    //Needs it generic to use in a lot of derived classes
    private String ConcatIds<T>(List<T> listObj)
    {
        String ids = String.Empty;
        foreach (T obj in listObj)
        {
            BaseEntity be = CastBack(obj);
            if (ids.Count() > 0)
                ids = ids + String.Format(", {0}", be.Id);
            else
                ids = be.Id.ToString();
        }
        return ids;
    }
    //I'll probably move it to the Base Class itself
    private BaseEntity CastBack<T>(T genericObj)
    {
        Type type = typeof(T);
        if (type.BaseType == typeof(BaseEntity))
        {
            Object _obj = (Object)genericObj;
            return (BaseEntity)_obj;
        }
        else
        {
            throw new InvalidOperationException(String.Format("Cannot convert {0} to BaseEntity", type.ToString()));
        }
    }
