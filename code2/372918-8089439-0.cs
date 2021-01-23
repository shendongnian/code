    StringBuilder sb = new StringBuilder();
    sb.Append("INSERT ... "); // put insert statement into here. I think question marks (?) or @fieldname both work.
    using (iDB2Connection conn = new iDB2Connection(_connString)){
    using (iDB2Command cmd = new iDB2Command(sb.ToString(), conn)){
       cmd.Parameter.Add("@fieldname", iDB2Type.Char).Value = value1;
       // fill these all in
       cmd.ExecuteNonQuery();
    }
    }
