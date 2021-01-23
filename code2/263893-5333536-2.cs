    public static T IsNull<T>(IDataReader dr, Int32 index) where T: IConvertible 
    {
        if (dr.IsDBNull(index))
        {
            return default(T);
        }
        else
        {
            return (T)Convert.ChangeType(dr.GetValue(index), typeof(T));
        }
    }
