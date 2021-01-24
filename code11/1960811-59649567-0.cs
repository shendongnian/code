    //Function for retrieving data from ms access database and displaying it on DataGridView
    public void populateDataGridView()
    {
        //First, clear all rows before populating datagridview with data from MS Access Database. Check if datagridview rows are empty before clearing.
        if (dataGridView1.Rows.Count > 0)
        {
            dataGridView1.Rows.Clear();
        }
        try
        {
            accessDatabaseConnection.Open();
            //OleDbDataAdapter adapter = new OleDbDataAdapter(sqlQuery, acceddDatabaseConnection);
            OleDbCommand command = new OleDbCommand(selectDataFromMSAccessDatabaseQuery, accessDatabaseConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[8].GetType());
                dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString(), reader[6].ToString(), reader[7].ToString(), (byte[])reader[8]);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.StackTrace);
        }
        finally
        {
            //Finally Close MS Access Database Connection
            if (accessDatabaseConnection != null)
            {
                accessDatabaseConnection.Close();
            }
        }
    }
