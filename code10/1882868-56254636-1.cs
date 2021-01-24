    protected void Button1_Click1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GridView1.Rows)
        {
            if ((row.FindControl("CheckBox1") as CheckBox).Checked)
            {
                SqlCommand cmd = new SqlCommand("insert into PrescTest (nameTest) values (@Test)", conn);
                cmd.Parameters.Add("Test", SqlDbType.NVarChar, 50).Value = ((HiddenField)row.FindControl("hdnnameTest")).Value;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
    
