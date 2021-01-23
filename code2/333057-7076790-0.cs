    ....
    using (SqlDataReader myReader = cmd.ExecuteReader())
    {
       DataTable myTable = new DataTable();
       myTable.Load(myReader);
       cmd.Connection.Close();
       Dim myDataSet As New DataSet()
       myDataSet.Tables.Add(myTable)
       return myDataSet;
    }
