    public static T IsNull<T>(IDataReader dr, Int32 index)
    {
        if (dr.IsDBNull(index))
        {
            return default(T);
        }
        else
        {
            return (T)dr.GetValue(index);
        }
    }
