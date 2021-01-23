    public static T FillDataRecord<T>(IDataRecord dr) where T : new()
    {
        T returnedInstance = new T();
        string fieldName = default(string);
        try
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
    
            fieldName = dr.GetName(i);
            foreach (PropertyInfo property in properties)
            {
                if (property.Name == fieldName)
                {
                    // Handle the DBNull conversion issue..
                    if (dr.GetValue(i) == DBNull.Value)
                        property.SetValue(returnedInstance, null, null);
                    else
                        property.SetValue(returnedInstance, dr[i], null);
                }
            }
    
            return returnedInstance;
        }
        catch (Exception ex)
        {
            // Handle exception here
        }
    }
