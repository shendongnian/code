    var query = (DbQuery<int>)result;
        
    FieldInfo internalQueryField = query.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.Name.Equals("_internalQuery")).FirstOrDefault();
    var internalQuery = internalQueryField.GetValue(query);
    FieldInfo objectQueryField = internalQuery.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => f.Name.Equals("_objectQuery")).FirstOrDefault();
    ObjectQuery<int> objectQuery = objectQueryField.GetValue(internalQuery) as ObjectQuery<int>;
        
    foreach (ObjectParameter objectParam in objectQuery.Parameters)
    {
        SqlParameter sqlParam = new SqlParameter(objectParam.Name, objectParam.Value);
        // Etc...
    }
