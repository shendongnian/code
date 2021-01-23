    [DebuggerStepThrough]
    public static T TryGet<OT, T>(this OT obj, params Expression<Func<OT, T>>[] getters)
    {
        T ret = default(T);
        if (getters != null)
        {
            foreach (var getter in getters)
            {
                try
                {
                    if (getter != null)
                    {
                        var getter2 = (Func<OT, T>)getter.Compile();
                        ret = getter2(obj);
                        break;
                    }
                }
                catch
                { /* try next getter or return default */ }
            }
        }
        return ret;
    }
