    using(var connection = new LinqToSqlDBContext())
    {
        foreach(var obj in MyObjects)
        {
            connection.StoredProc1(obj.Name);
            connection.StoredProc2(obj.Name);       
        }
    }
