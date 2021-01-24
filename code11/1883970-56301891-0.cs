    public void DeleteData([FromBody]NewsId newsId)
    {
        conn.ConnectionString = mdc.ConnectonString;
        cmd.Connection = conn;
        if (newsId.id.Length > 0)
