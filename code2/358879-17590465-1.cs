    protected void Button3_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = null;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=shoping;User ID=sa;Password=yamini");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select email from usertd where @email='" + TextBox1.Text + "' ", con);
            cmd.Parameters.AddWithValue("@email", TextBox1.Text);
            dr = cmd.ExecuteReader;
            if (dr != null && dr.HasRows)
            {
                TextBox2.Text = "abc";
            }
            else
            {
                TextBox2.Text = "hdc";
            }
    
        }
