    private B CastBack<T,B>(T genericObj)
    {
        Type type = typeof(T);
        if (type.BaseType == typeof(B))
        {
            Object _obj = (Object)genericObj;
            return (B)_obj;
        }
        else
        {
            throw new InvalidOperationException(String.Format("Cannot cast back {0}", type.ToString()));
        }
    }
