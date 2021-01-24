    dtResponseTimes.AsEnumerable().GroupBy(x => x["X_Axis_Categories"].ToString()).Select(x =>
    {
        var keyValues = new Dictionary<string, object>();
        keyValues.Add("URL", x.Key);
        foreach (DataColumn column in dtResponseTimes.Columns)
        {
            if (column.ColumnName.Contains("ResponseTime"))
            {
                keyValues.Add(
                    column.ColumnName, 
                    x.Average(Y => Convert.ToInt32(Y[column.ColumnName]))
                );
            }
        }
        return keyValues;
    }
