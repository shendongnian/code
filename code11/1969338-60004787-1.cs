private void button1_Click(object sender, EventArgs e)
{
    try
    {
        using(OleDbConnection connection = new OleDbConnection())
        {
            connection.ConnectionString = @".....";
            connection.Open();
            string query = @"insert into userLogin(username,[password])
                             values(@user, @pass)";
            OleDbCommand cmd = new OleDbCommand(query,connection);
            cmd.Parameters.Add("@user", OleDbType.VarWChar).Value = tuser.Text;
            cmd.Parameters.Add("@pass", OleDbType.VarWChar).Value = tpassword.Text;
            int a = cmd.ExecuteNonQuery();
        }
    }
    catch (Exception c)
    {
        MessageBox.Show("Error"+c);
    }
}
  [1]: https://bobby-tables.com/
  [2]: https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp
