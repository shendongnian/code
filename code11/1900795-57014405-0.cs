    namespace Helper
    {
     public static class ConvertEX1
        {
            public static object IsNull<T>(this object obj, T def) where T : struct
            {
                if (obj == null || obj == DBNull.Value)
                    return (T)Convert.ChangeType(def, typeof(T));
                return (T)Convert.ChangeType(obj, typeof(T));
            }
        }
    }
