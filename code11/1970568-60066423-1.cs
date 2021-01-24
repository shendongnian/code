    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]  // To Force the service method to return JSON only
    public static List<MyData> DoStuff()
    {
        DataTable table = FetchMyTable(); // method that gets your data from SQL
        List<MyData> data = new List<MyData>();
        foreach(DataRow row in table.Rows)
        {
            MyData dataItem = new MyData
            {
                Column1 = row["Column1"].ToString(),
                Column2 = row["Column2"].ToString(),
                // And So on...
            };
            data.Add(dataItem);
        }
        return data;
    }
