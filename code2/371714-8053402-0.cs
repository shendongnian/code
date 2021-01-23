    var emps = members.Select( (e,i) => "@EMPLOYEE" + i).ToArray();
    string sqlQuery = "SELECT * FROM table WHERE ";
    sqlQuery+=string.Format("UserName IN ({0})", string.Join(",", emps));
    //add SQL parameters used in query
    for (int i = 0; i < members.Count; ++i) 
    {
        parameters.Parameters.Add(new SqlParameter("@EMPLOYEE" + i, members[i])); 
    }
