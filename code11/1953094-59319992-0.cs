    connection.Open();
    string updateQuery = "UPDATE [c1 barcode], [c2 barcode] SET [c1 barcode].[Close from care] = [c2 barcode].[close from care], [c1 barcode].[Name care] = [c2 barcode].[name care] WHERE ([c1 barcode].Workorder=[c2 barcode].[workorder]);";
    string insertQuery = "INSERT INTO [c1 barcode] SELECT * FROM [c2 barcode] c2 WHERE NOT EXISTS (SELECT 1 FROM [c1 barcode] WHERE Workorder = c2.Workorder)";
    using (OleDbCommand cmd = new OleDbCommand(updateQuery, connection))
    {
        if ((int)cmd.ExecuteNonQuery() > 0)
        {
            MessageBox.Show("updated");
        }
    }
    using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
    {
        if ((int)cmd.ExecuteNonQuery() > 0)
        {
            MessageBox.Show("inserted");
        }
    }
    connection.Close();
