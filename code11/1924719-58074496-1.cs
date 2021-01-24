    using (connection)
        {
            SqlCommand command = new SqlCommand(
              "select voicename from tblfiles5 where voicename='" + TextBox1.Text + "'",
              connection);
            connection.Open();
    
            SqlDataReader reader = command.ExecuteReader();
    
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                        string link = "<audio controls> <Source src='"+ 
                        reader.GetString(0) + "' type ='audio/wav' ></audio>";
                        Literal1.InnerHtml = link;
                }
            }
            else
            {
                        MessageBox.Show("No "+ TextBox1.Text+" exist in database");
            }
            reader.Close();
        }
