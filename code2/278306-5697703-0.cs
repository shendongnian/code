    [TableName("Customers")]
    class Customer : RecordBase { }
    //...
    public static IEnumerable<T> GetRecords<T>(this DataSet MySet) where T : RecordBase
    {
        var attribT = typeof(TableAttribute);
        var attrib  = (TableAttribute) typeof(T).GetCustomAttributes(attribT,false)[0];
        foreach (DataRow row in MySet.Tables[attrib.TableName].Rows)
        {
            yield return (T) Activator.CreateInstance(typeof(T),new[]{row});
        }
    }
