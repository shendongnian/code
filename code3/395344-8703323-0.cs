    var conn = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES"";", opFileImport.FileName);
    string sql = "Select CODICE_FISCALE From [Parte_4$] ";
    sql += "where CODICE_FISCALE = ?";
    DataTable dt = new DataTable();
    using (OleDbConnection excelConn = new OleDbConnection(conn))
    {
        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
        {
            dataAdapter.SelectCommand = new OleDbCommand(sql, excelConn);
            dataAdapter.SelectCommand.Parameters.Add(new OleDbParameter("CODICE_FISCALE", strCodFisc));
            dataAdapter.Fill(dt);
        }
    }
