    DataTable dt = new DataTable(); 
    dt.Columns.Add("id", typeof(String)); 
    dt.Columns.Add("name", typeof(String)); 
    for (int i = 0; i < 5; i++)
    {
        string index = i.ToString();
        dt.Rows.Add(new object[] { index, "name" + index });
    }
