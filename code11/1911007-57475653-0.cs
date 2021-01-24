    string sqlText = @"select * from Appointment 
                       where AppoinmentDate=@aptDate 
                         and Slot=@slot 
                         and HRName=@name";
    using(SqlConnection cnn = new SqlConnection(connectionString))
    using(SqlCommand slot_check = new SqlCommand(sqlText, cnn))
    {
         cmd.Parameters.Add("@aptDate", SqlDbType.Date).Value = Convert.ToDateTime(textBox1.Text);
         cmd.Parameters.Add("@slot", SqlDbType.NVarChar).Value = comboBox3.Text;
         cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = comboBox2.Text;
         cnn.Open();         
         using(SqlDataReader Exist = slot_check.ExecuteReader())
         {
             if (Exist.HasRows)
             {
                    string message = "Appointment Already Exists!!!!!";
                    MessageBox.Show(message + " " + Exist + comboBox2.Text);
             }
             else
             {
                    string message = "Update";
                    MessageBox.Show(message);
             }
        }
    }
