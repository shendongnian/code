    // The command text to run, without string concatenations and with parameters placeholders
    string sqlText = @"select * from Appointment 
                       where AppoinmentDate=@aptDate 
                         and Slot=@slot 
                         and HRName=@name";
    // Using statement to correctly close and dispose the disposable objects
    using(SqlConnection cnn = new SqlConnection(connectionString))
    using(SqlCommand slot_check = new SqlCommand(sqlText, cnn))
    {
         // A parameter for each placeholder with the proper datatype
         cmd.Parameters.Add("@aptDate", SqlDbType.Date).Value = Convert.ToDateTime(textBox1.Text);
         cmd.Parameters.Add("@slot", SqlDbType.NVarChar).Value = comboBox3.Text;
         cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = comboBox2.Text;
         cnn.Open();         
         // Even the SqlDataReader is a disposable object
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
