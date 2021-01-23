    DataTable _test = new DataTable();
    DataColumn c = new DataColumn("sno", typeof(int));
    c.AutoIncrement = true;
    c.AutoIncrementSeed = 1;
    c.AutoIncrementStep = 1;
    _test.Columns.Add(c);
    _test.Columns.Add("description");
    gvlisting.DataSource = _test;
