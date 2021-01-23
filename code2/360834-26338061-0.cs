    var columns = new List<Tuple<string, string>>();
    columns.Add(new Tuple<string, string>("Name", "System.String"));
    columns.Add(new Tuple<string, string>("Selected", "System.Boolean"));
    columns.Add(new Tuple<string, string>("Id", "System.Int32"));
    var table = new DataTable();
    columns.ForEach(c => table.Columns.Add(new DataColumn(c.Item1) { DataType = Type.GetType(c.Item2) }));
    var dgv = new DataGridView();
    dgv.DataSource = table;
