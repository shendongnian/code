     SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VEFPLGG\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");    
     private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            String query = "UPDATE Table_com SET Contents=@contents ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.Add("@contents", SqlDbType.Float).Value = textBox6.Text;
                    //cmd.Parameters.Add("@variable", SqlDbType.Float).Value = Convert.ToDouble(comboBox5.Text);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
        }
