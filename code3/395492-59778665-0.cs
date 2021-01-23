    private void Form_Load(object sender, EventArgs e) {
            DataSQLite.OpenDB();      // this line to open connection to Database
            DataTable tbl = DataSQLite.GetData("SELECT * from tableName");
            for (int i = 0; i < tbl.Rows.Count; i++) {
                DGVData.Rows.Add();  // this line will create new blank row
                for (int j = 0; j < Numberofcolumns; j++) {
                    DGVData.Rows[i].Cells[j].Value = tbl.Rows[i][j].ToString();
                }
            }
        }
