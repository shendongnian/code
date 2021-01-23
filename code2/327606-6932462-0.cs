    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("calendar.CropTime", c))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.DateTime).Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.AddWithValue("@d", DateTime.Now);
        cmd.ExecuteNonQuery();
        textBox1.Text = cmd.Parameters["@RETURN_VALUE"].Value.ToString();
    }
