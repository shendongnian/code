    void Main()
    {
    	string data = @"Product,Price,Condition
    Cd,13,New
    Book,9,Used
    ";
    	var table = ToTable(data);
    	Form f = new Form();
    	var dgv = new DataGridView { Dock = DockStyle.Fill, DataSource = table };
    	f.Controls.Add(dgv);
    	f.Show();
    }
    
    private DataTable ToTable(string CSV)
    {
    	DataTable dataTable = new DataTable();
    	var lines = CSV.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    	foreach (var colname in lines[0].Split(','))
    	{
    		dataTable.Columns.Add(new DataColumn(colname));
    	}
    	foreach (var row in lines.Where((r, i) => i > 0))
    	{
    		dataTable.Rows.Add(row.Split(','));
    	}
    	return dataTable;
    }
