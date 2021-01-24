    public DataTable importaExcelaDT(string file)
            {
    DataTable dt = new DataTable();
    DataTable dtExcel = new DataTable();
    OleDbCommand cmdExcel = new OleDbCommand();
    string cadenaConexion = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + file + "';Extended Properties = \"Excel 12.0 Xml;HDR=No;IMEX=1\";";
    OleDbConnection olConexion = new OleDbConnection(cadenaConexion);
    olConexion.Open();
    OleDbDataAdapter oda = new OleDbDataAdapter();
    dt = olConexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
    string sheet = dt.Rows[0]["TABLE_NAME"].ToString();
    cmdExcel.Connection = olConexion;
    cmdExcel.CommandText = "SELECT * FROM [" + sheet + "]"; 
    oda.SelectCommand = cmdExcel;
    oda.Fill(dtExcel);
    olConexion.Close();
    olConexion.Dispose();
    oda.Dispose();
    return dtExcel;
    }
