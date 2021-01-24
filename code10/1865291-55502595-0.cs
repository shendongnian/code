        connection.Open();
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        command.CommandText = "select * from appointments where patientNo = '" + Lastname.Text + "' ";
        OleDbDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Firstname.Text = reader["firstName"].ToString();
            patientNum.Text = reader["patientNo"].ToString();
            contactNum.Text = reader["contactNo"].ToString();
        }
        connection.Close();
