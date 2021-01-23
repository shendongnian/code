    // Stock is table name
    // metal id is unique number that is auto generated as well as auto incremented
 
    private void textBox9_TextChanged(object sender, EventArgs e)
    {
        string s = "select max(metalid)+1 from stock";
        SqlCommand csm = new SqlCommand(s, con);
        con.Open();
        csm.ExecuteNonQuery();
        SqlDataReader dd = csm.ExecuteReader();
        while (dd.Read())
        {
            int n = dd.GetInt32(0);
            textBox1.Text = n.ToString();
        }
         con.Close();
    }
