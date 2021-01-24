    string query = $"SELECT * FROM [{sheetName}$B6:ZZ] WHERE FCID = '204'"
    using (OleDbConnection cnnxls = new OleDbConnection(strConn))
    using (OleDbDataAdapter oda = new OleDbDataAdapter(query, cnnxls))
    {
        oda.Fill(tbContainer);
        grdProductList.DataSource = tbContainer;
    }
