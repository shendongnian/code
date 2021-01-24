    string query= "SELECT * FROM  alunos where Estado=@state";
    if(a.open_connection() == true)
    {
        MySqlCommand cmd = new MySqlCommand(query, a.connection);
        cmd.Parameters.Add("@state", MySqlDbType.VarChar).Value = textBox1.Text;
        MySqlDataReader dataReader= cmd.ExecuteReader();
        if(dataReader.HasRows)
        {
            DataTable dt= new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource= dt;
        }
    
        dataReader.Close();
        a.close_connection();
    }
