    public static List<T> ToList<T>(this IDataReader idr, int count) where T : new()
    {
        if (idr == null)
            throw new ArgumentNullException("idr");
        if (idr.IsClosed)
            throw new ArgumentException("IDataReader is closed.");
        Type businessEntityType = typeof(T);
        List<T> entitys = new List<T>();
        Hashtable hashtable = new Hashtable();
        PropertyInfo[] properties = businessEntityType.GetProperties();
        int idx = 0;
        foreach (PropertyInfo info in properties)
        {
            hashtable[info.Name.ToUpper()] = info;
        }
        while (idr.Read())
        {
            if (count > 0)
                idx++;
            T newObject = new T();
            for (int index = 0; index < idr.FieldCount; index++)
            {
                PropertyInfo info = (PropertyInfo)hashtable[idr.GetName(index).ToUpper()];
                if (info != null && info.CanWrite)
                {
                    try
                    {
                        info.SetValue(newObject, idr.GetValue(index), null);
                    }
                    catch
                    {
                    }
                }
            }
            entitys.Add(newObject);
            if (idx > count)
                break;
        }
        return entitys;
    }
