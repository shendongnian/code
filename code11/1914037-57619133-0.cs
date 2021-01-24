protected void btnInsertion_Click(object sender, EventArgs e)
{
        using (NpgsqlConnection connection = new NpgsqlConnection())
        {
        connection.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
            connection.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "Insert into student_folio (fieldname) values(@f_name)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new NpgsqlParameter(@f_name, txtFname.Text));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        connection.Close();
        txtFname.Text = "";            s
        }
}
