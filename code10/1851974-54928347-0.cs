    private void button6_Click(object sender, EventArgs e)
    {
        xcon.Open();
        SqlDataAdapter xadapter = new SqlDataAdapter();
        SqlCommand command = new SqlCommand(
        @"UPDATE dbo.SysX SET fp = @fp, sd = @sd, sf= @sf
        WHERE id = @id", xcon);
        command.Parameters.Add("@fp", SqlDbType.Int, Convert.ToInt32(textBox1.Text));
        command.Parameters.Add("@sd", SqlDbType.Int, Convert.ToInt32(textBox2.Text));
        command.Parameters.Add("@sf", SqlDbType.Int, Convert.ToInt32(textBox3.Text));
        command.Parameters.Add("@Id", SqlDbType.Int, 2019);
        // next command !!!
        command.ExecuteNonQuery();
        xadapter.UpdateCommand = command;
        xcon.Close();
    }
