    DataTable table = new DataTable();
    table.Columns.Add("Column", typeof(int));
    DataColumn column = table.Columns["Column"];
    column.Unique = true;
    column.AutoIncrement = true;
    column.AutoIncrementStep = 1; //change these to whatever works for you
    column.AutoIncrementSeed = 1;
    table.PrimaryKey = new DataColumn[] { column };
