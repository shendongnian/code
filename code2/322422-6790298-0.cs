    DataTable Contents = new DataTable();
    using (OleDbDataAdapter adapter = new OleDbDataAdapter("Select * From [Sheet1$]", objConn))
    {
        adapter.Fill(Contents);
    }
    Console.WriteLine(Contents.Rows[0][0]);
