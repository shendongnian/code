    private void buttonSave_Click(object sender, EventArgs e)
    {
        try
        {
            // The using block will automatically dispose of your connection when
            // the block is exited and is considered standard practice.
            using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename='G:\\C#.Net\\Forms Practice\\WindowsFormsPractice1\\WindowsFormsPractice1\\WindowsFormsPractice1.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True";))
            {
                SqlDataAdpter da = new SqlDataAdapter();
                connection.Open();
                // Assign the SqlConnection object to the SqlDataAdapter
                da.Connection = connection;
                // Parameterize the query as shown below
                string sql = "INSERT INTO TBLWORKERS(first_name, last_name) VALUES(@first_name, @last_name)";
                da.InsertCommand.CommandText = sql;
                // Add the values for the parameters
                da.InsertCommand.Parameters.Add("@first_name", SqlDbType.NVarChar, 25, StartValueTextBox.Text);
                da.InsertCommand.Parameters.Add("@last_name", SqlDbType.NVarChar, 25, EndValueTextBox.Text);
                // Execute the query - rows will have the number of rows
                // affected.  should be 1 in this case if succesful
                int rows = da.InsertCommand.ExecuteNonQuery();           
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Connection open");
        }
    }
