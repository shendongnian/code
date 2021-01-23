    function() {
    string sqltext2;
    sqltext2 = "INSERT into dbo.OwnerChanges ";
    SqlCommand myCommand2 = new SqlCommand(sqltext2, MyConnection2);
    
    if (cond1) {
        //no concatenating
        sqltext2 = sqltext2 + " SELECT @initOwnerFirstName , @ownerFirstName UNION ALL ";
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@initOwnerFirstName";
        param.Value = initOwnerFirstName;
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@ownerFirstName";
        param2.Value = owner.FirstName;
        myCommand2.Parameters.Add(param);
        myCommand2.Parameters.Add(param2);
