    using (var cnn = DB.DbConnection())
    {
        //var cnn = DB.DbConnection();
        cnn.Open();
        result = cnn.GetList<TPoco>(predicate);
        result = result.ToList();  // fetch records now 
    }
    return result;
