      public static string GetString(object o)
        {
            if (o == DBNull.Value)
                return "";
    
            return o.ToString();
        }
