    using (Conn = new SqlConnection(Conect))
    {
    Conn.Open();    
    SQL = "SELECT * FROM MEN where id = '" + txtBAR.Text.Trim() + "'";
    SqlCommand command= new SqlCommand(SQL,Conn);
    SqlDataReader reader = command.ExecuteReader()
    reader.Read();
    //Call Read to move to next record returned by SQL
    //OR call --While(reader.Read())
    txtFname.Text = reader[0].ToString();
    reader.Close();
    Conn.Close();
    }
