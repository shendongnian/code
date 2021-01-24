    var con = Program.GetConnection();
    con.Open();
    OleDbCommand cmd = new OleDbCommand();
    cmd.Connection = con;
    cmd.CommandType = CommandType.Text;
    
    cmd.CommandText = "UPDATE data  SET [QTY] = @value1 WHERE ID = @value2";
    cmd.Parameters.Add('@value1', OleDbType.Integer).value = textBox6.Text;
    cmd.Parameters.Add('@value1', OleDbType.Integer).value = textBox7.Text;
    cmd.Connection = con;
    
    cmd.ExecuteNonQuery();
    System.Windows.Forms.MessageBox.Show("Data Updated Successfully");
    con.Close();
