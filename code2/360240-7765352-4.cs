    public static int GetTotalLengthOfStringProperties(object obj)
    {            
        Type type = obj.GetType();
        PropertyInfo[] info = type.GetProperties();
    
        int total = info.Where(p => p.PropertyType == typeof (String))
                        .Sum(pr => (((String) pr.GetValue(obj, null)) 
                                   ?? String.Empty).Length);
        return total;
    }
