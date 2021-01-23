    // we decide we'll use results later, storing them temporarily here
    List<IEnumerable<string>> columnsValues = new List<IEnumerable<string>>();
    foreach (DataColumn column in temperature.Columns)
    {
        var values = temperature.Rows.OfType<DataRow>()
                                     .Select(r => r[column].ToString())
        columnsValues.Add(values);
    }
