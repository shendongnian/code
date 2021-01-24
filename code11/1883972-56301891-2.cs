    public void RemoveData([FromBody]NewsId newsId) // <-- Change method's name from "DeleteData" to "RemoveData"
    {
        conn.ConnectionString = mdc.ConnectonString;
        cmd.Connection = conn;
        if (newsId.id.Length > 0)
