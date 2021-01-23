    string strcon = ConfigurationSettings.AppSettings["Constring"].ToString();
    MySqlConnection conn = new MySqlConnection(strcon);
    MySqlCommand cmd = new MySqlCommand("Select * From items order by ItemID", conn);
    conn.Open();
    MySqlDataReader reader = cmd.ExecuteReader();
    if (reader.HasRows)
    {
       dataGridView1.Visible = true;
       DataTable dt = null;
       dt = new DataTable();
       dt.Load(reader);
       dataGridView1.DataSource = dt;
    }
