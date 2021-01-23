    var myArray = new string[] { "1", "2", "3" };
    //var sql = string.Format("SELECT * FROM myTable WHERE myColumn in ({0})", string.Join(", ", myArray));
    var cmd = new System.Data.SqlClient.SqlCommand();
    var sql = new System.Text.StringBuilder();
    sql.Append("SELECT * FROM myTable WHERE myColumn in (");
    for (var i = 0; i < myArray.Length; i++)
    {
        cmd.Parameters.Add("@" + i, myArray[i]);
        if (i > 0) sql.Append(", ");
        sql.Append("@" + i);
    }
    sql.Append(")");
    cmd.CommandText = sql.ToString();
