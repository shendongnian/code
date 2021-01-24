    SQLiteDataAdapter sda = new SQLiteDataAdapter();
    sda.SelectCommand = cmdDataBase;
    DataTable dbdataset = new DataTable();
    sda.Fill(dbdataset);
    DataTable dbdatasetclone = dbdataset.Clone();
    dbdatasetclone.Columns[0].DataType = typeof(DateTime);           
    foreach (DataRow row in dbdataset.Rows)
    {
        dbdatasetclone.ImportRow(row);
    }
    BindingSource bSource = new BindingSource();
    bSource.DataSource = dbdatasetclone;
    dataGridView1.DataSource = bSource;
    dataGridView1.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
