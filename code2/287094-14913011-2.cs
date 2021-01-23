    void Main()
    {
    	GetDataTable().Dump();
    }
    public DataTable GetDataTable()
    {
    	var dt = new DataTable();	
    	dt.Columns.Add("Id", typeof(string)); // dt.Columns.Add("Id", typeof(int));
    	dt.Columns["Id"].Caption ="my id";	
    	dt.Columns.Add("Name", typeof(string));
    	dt.Columns.Add("Job", typeof(string));
    	dt.Rows.Add(GetHeaders(dt));
    	dt.Rows.Add(1, "Janeway", "Captain");
    	dt.Rows.Add(2, "Seven Of Nine", "nobody knows");
    	dt.Rows.Add(3, "Doctor", "Medical Officer");
    	return dt;
    }
    
    public DataRow GetHeaders(DataTable dt)
    {
    	DataRow dataRow = dt.NewRow();    	
    	string[] columnNames = dt.Columns.Cast<DataColumn>()
                                     .Select(x => x.ColumnName)
                                     .ToArray();  	
    	columnNames.Dump();
    	dataRow.ItemArray = columnNames;
    	return dataRow;
    }
