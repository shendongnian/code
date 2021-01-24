    string query = "select * from Eligibility where Name = @Name";
                sql.Open();
            SqlCommand cmd = new SqlCommand(query, sql);
            cmd.Parameters.Add("@Name", SqlDbType.Text);
            cmd.Parameters["@Name"].Value = textBox1.Text;
                SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label6.Text = (dr["name"].ToString());
            }
                sql.Dispose();
                if (label6.Text == textBox1.Text)
                    {
                        this.Hide();
                        UserHomeView uhv = new UserHomeView();
                        uhv.Show();
                    }
                    else
                    {
                        this.Hide();
                        Eligibility eli = new Eligibility();
                        eli.Show();
                    }
