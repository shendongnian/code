    string sql = @"
        select  x,y,z,t,ModifiedDate 
        from  ZZ 
        where PP= @XX and Type= @YY 
        order by ModifiedDate";
    DataTable dt = new DataTable();
    // .Net connection pooling means you really do want a new connection object most of the time. Don't try to re-use it!
    // The "using" blocks make sure your objects are closed and disposed, even if an exception is thrown
    using (var con = new SqlConnection("connection string here"))
    using (var cmd = new SqlCommand(sql, con))
    using (var da = new SqlDataAdapter(cmd))
    {
        //use the actual column types and lengths from your database here
        cmd.Parameters.Add("@XX", SqlDbType.NVarChar, 30).Value = XX;
        cmd.Parameters.Add("@YY", SqlDbType.NVarChar, 10).Value = YY;
        da.Fill(dt);
    }
