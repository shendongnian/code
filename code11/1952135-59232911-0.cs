        string query = @"IF EXISTS(SELECT * FROM u_Data WHERE TAG = @Tag)
                            UPDATE u_data SET NIK = @Nik, Department = @Department 
                            WHERE TAG = @Tag
                            ELSE
                            INSERT INTO u_Data (TAG, Name, NIK, Department) VALUES(@Tag, @Name, @Nik, @Department);";
        //create connection and command in "using" blocks
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.Add("@Tag", SqlDbType.VarChar, 100).Value = txtTag.Text;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 200).Value = txtName.Text;
            cmd.Parameters.Add("@Nik", SqlDbType.VarChar, 100).Value = txtNIK.Text;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 100).Value = txtDept.Text;
            // open connection, execute query, close connection
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
        }
