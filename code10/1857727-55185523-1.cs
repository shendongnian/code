    try
    {
        DataSet records = new DataSet();
        using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\n0740572\Projects\newest\CW\CW\Database1.mdf;Integrated Security=True"))
        {
            int? userId = null;
            using (SqlCommand command = new SqlCommand("select UserID from Users where Username = @Username", conn))
            {
                command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = loggedInLabel.Text;
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                    if (reader.Read())
                        userId = reader.GetInt32(reader.GetOrdinal("UserID"));
                conn.Close();
            }      
            if (userId == null) // No row found
                throw new ApplicationException("User not found");
            using (SqlCommand command = new SqlCommand("select * from Records where UserID = @CurrentUserID", conn))
            {
                command.Parameters.Add("@CurrentUserID", SqlDbType.Int).Value = userID.Value;
        
                // SqlDataAdapter opens and closes the connection itself.
                using (SqlDataAdapter dataadapter = new SqlDataAdapter(command))
                    dataadapter.Fill(records , "Records");
            }
        }
        //update datagridview    
        dataGridView.DataSource = records ;
        dataGridView.DataMember = "Records";
    } 
    catch (SqlException ex)
    {
        MessageBox.Show(ex.Message);
    } 
    
