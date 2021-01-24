    var data = new DataTable();
    data.Columns.Add("Data", typeof(string));
    data.Rows.Add("1");
    data.Rows.Add("2.0");
    data.Rows.Add("3.25 kg");
    data.Rows.Add(DBNull.Value);
    
    var sum = data.AsEnumerable()
    .Where(d => d["Data"] != DBNull.Value)
    .Sum(d =>
    {
    	var columnData = d["Data"].ToString();
    	var numericalString = new string(columnData.Where(c => char.IsDigit(c) || c == '.').ToArray());
    	var numericalValue = decimal.Parse(numericalString);
    
    	return numericalValue;
    });
