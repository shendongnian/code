    private volatile Dictionary<string, int> i_MapObj = new Dictionary<string, int>();
    private void Update()
    {
        DataTable dataTable = dbClient.ExecuteDataSet(i_Query).GetFirstTable();
        var newData = new Dictionary<string, int>();
        foreach (DataRow currRow in dataTable.Rows)
        {
            newData.Add(Convert.ToString(currRow[i_Column1]), Convert.ToInt32[i_Column2]));
        }
        // Start using new data - reference assignments are atomic
        i_MapObj = newData;
    }
    private int? GetValue(string key)
    {
        int value;
        if (i_MapObj.TryGetValue(key, out value))
            return value;
        return null;
    }
