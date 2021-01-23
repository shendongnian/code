    foreach(var obj in MyObjects)
    {
        using(var connection = new LinqToSqlDBContext())
        {
            connection.StoredProc1(obj.Name);
            connection.StoredProc2(obj.Name);
        }
    }
