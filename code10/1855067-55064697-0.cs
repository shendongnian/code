    conect.Open();
    OleDbCommand command = conect.CreateCommand();
    command.CommandType = CommandType.Text;
    command.CommandText = "select * from Sign_Up where UserName='"+Username.Text+"'";
    //command.ExecuteNonQuery(); no need to execute command manually
    DataTable dt = new DataTable();
    OleDbDataAdapter da = new OleDbDataAdapter();
    da.SelectCommand = command; //add this line
    da.Fill(dt);
    dataGridView1.DataSource = dt;
    conect.Close();
