    public static T FillDataRecord<T>(IDataRecord dr) where T: new()
    {
        T returnedInstance = new T();
        try
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
    
            fieldName = record.GetName(i);
            foreach (PropertyInfo property in properties)
            {
                if (property.Name == fieldName)
                {
                    // Handle the DBNull conversion issue..
                    if (record.GetValue(i) == DBNull.Value)
                        property.SetValue(returnedInstance, null, null);
                    else
                        property.SetValue(returnedInstance, record[i], null);
                }
            }
    
            return returnedInstance;
        }
        catch (Exception ex)
        {
            // Handle exception here
        }
    }
