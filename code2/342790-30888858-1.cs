    System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source = " + strFileName + "; Extended Properties = \"Excel 8.0;HDR=NO;IMEX=1\";"); /*for office 2007 connection*/
                        conn.Open();
    string strQuery = "SELECT * FROM [" + Table + "]";
    System.Data.OleDb.OleDbDataAdapter adapter = new  System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
    System.Data.DataTable ExcelToDataTable = new System.Data.DataTable();
    adapter.Fill(ExcelToDataTable);
    DT = ExcelToDataTable.Copy();
   
    int count = DT.Rows.Cast<DataRow>().Where(row => row.ItemArray.All(field => field is System.DBNull || string.Compare((field as string).Trim(), string.Empty) == 0)).ToList().Count();
