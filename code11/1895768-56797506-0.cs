    string cmddt=
                @"INSERT INTO WALLETTBL(sum, date, categoryID, type)   
        VALUES (@Sum, @Date, @CategoryId, @Type);";
    
             using (SqlConnection conn = new SqlConnection(ConnectionString))
             {
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                   cmd.Parameters.Add("@Sum", SqlDbType.Int).Value = textBox1.Text;
                   cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = textBox2.Text;
                   cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value =  Convert.ToInt32(comboBox1.SelectedValue);
                   cmd.Parameters.Add("@Type", SqlDbType.Varchar).Value = type;
                   await conn.OpenAsync();
                   await cmd.ExecuteNonQueryAsync();
                }
             }
