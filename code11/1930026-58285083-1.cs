    var records = new Dictionary<string, Dictionary<DateTime, double?>>();
    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
    {
        using (var reader = ExcelReaderFactory.CreateReader(stream))
        {
            var firstTable = reader.AsDataSet().Tables[0];
                    
            for (int i = 1; i < firstTable.Rows.Count; i++)
            {
                string name = firstTable.Rows[i].Field<string>(0);
                var dt_values = new Dictionary<DateTime, double?>();
                for (int j = 1; j < firstTable.Columns.Count; j++)
                {
                    DateTime dt = firstTable.Rows[0].Field<DateTime>(j);
                    double? value = firstTable.Rows[i].Field<double?>(j);
                    dt_values.Add(dt, value);
                }
                records.Add(name, dt_values);
            }
       }
    }
    var formatted_data = records.SelectMany(x => x.Value.Select(y => new
    {
        Name = x.Key,
        Dos = y.Key.ToShortDateString(),
        CPT = y.Value
    }));
