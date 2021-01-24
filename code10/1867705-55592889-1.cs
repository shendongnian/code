    string contents = File.ReadAllText(@"test.txt");
    
    string pattern = @"(.*?)\s(\d+)";
    
    var query = contents.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
    				.Where(x => Regex.IsMatch(x, pattern))
    				.Select(x => Regex.Match(x, pattern))
    				.Select(x => new
    				{
    					Name = x.Groups[1].Value,
    					Value = Convert.ToInt32(x.Groups[2].Value)
    				});
    
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
    dataTable.Columns.Add(new DataColumn("Value", Type.GetType("System.Int32")));
    
    foreach (var item in query)
    {
    	DataRow dr = dataTable.NewRow();
    	dr["Name"] = item.Name;
    	dr["job1"] = item.Value;
    	dataTable.Rows.Add(dr);
    }
