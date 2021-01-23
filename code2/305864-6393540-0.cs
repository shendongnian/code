    var clipData = Clipboard.GetData(DataFormats.Text).ToString();
    if (string.IsNullOrEmpty(clipData))
	    return;
    var dataSource = new DataTable("data");
    dataSource.Columns.Add("lines"); 
    foreach(var line in clipData.Split('\n'))
     	dataSource.Rows.Add(line);
					
    datagrid.DataSource = dataSource;
