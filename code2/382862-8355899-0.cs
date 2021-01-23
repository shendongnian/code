    //if myList is a list of CoreGrid or derived.
    string export = ExportEvents(myList);
    public string ExportEvents<T>(List<T> events) where T : CoreGrid
    {
        DataTable report = new DataTable();
        Type t = typeof(T);
        PropertyInfo[] props = t.GetProperties();
        foreach (PropertyInfo prop in props)
        {
            if (!prop.Name.Contains("ID"))
            {
                report.Columns.Add(prop.Name);
            }
        }
        foreach (var item in events)
        {
            DataRow dr = report.NewRow();
            Type itemType = item.GetType();
            PropertyInfo[] itemProps = itemType.GetProperties();
            foreach (PropertyInfo prop in itemProps)
            {
                if (report.Columns.Contains(prop.Name))
                {
		    var propValue = prop.GetValue(item, null)
                    if (propValue != null)
                    {
                        dr[prop.Name] = propValue.ToString().Replace(",", string.Empty);
                    }
                }
            }
            report.Rows.Add(dr);
        }
        return GenerateCSVExport(report, ExportType.Events);
    }
