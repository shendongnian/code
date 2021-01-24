    using(OleDbConnection connection = new OleDbConnection(.....))
    using(OleDbCommand command = new OleDbCommand("SELECT AL From Users WHERE Username=@name", connection);
    {
        connection.Open();
        command.Parameters.Add("@name", OleDbType.VarWChar).Value = txtusername.text;
        using(OleDbDataReader reader = command.ExecuteReader())
        {
            if( reader.Read())
            {
               MessageBox.Show("success","status");
               label1.Text = reader.GetString(0);
            }
            else
               MessageBox.Show("failur", "status");
        } 
    }    
