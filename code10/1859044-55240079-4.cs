    int fieldID = 204;
    //
    string query = $"SELECT * FROM [{sheetName}$B6:ZZ] WHERE FCID = '{fieldID}'"
    using (OleDbConnection cnnxls = new OleDbConnection(strConn))
    using (OleDbDataAdapter oda = new OleDbDataAdapter(query, cnnxls))
    {
        oda.Fill(tbContainer);
        grdProductList.DataSource = tbContainer;
    }
