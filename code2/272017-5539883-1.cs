    private void deleteRecord()
    {
        if (BooksGrid.SelectedRows.Count > 0)
        {
            int selectedIndex = BooksGrid.SelectedRows[0].Index;
            int rowID = int.Parse(BooksGrid[0, selectedIndex].Value.ToString());
            string sql = "DELETE FROM Table1 WHERE RowID = @RowID";
            SqlCommand deleteRecord = new SqlCommand();
            deleteRecord.Connection = Booksconnection;
            deleteRecord.CommandType = CommandType.Text;
            deleteRecord.CommandText = sql;
            SqlParameter RowParameter = new SqlParameter();
            RowParameter.ParameterName = "@RowID";
            RowParameter.SqlDbType = SqlDbType.Int;
            RowParameter.IsNullable = false;
            RowParameter.Value = rowID;
            deleteRecord.Parameters.Add(RowParameter);
            deleteRecord.Connection.Open();
            deleteRecord.ExecuteNonQuery();
            deleteRecord.Connection.Close();
            booksDataset1.GetChanges();
            sqlDataAdapter1.Fill(booksDataset1.Videos);
        }
    }
