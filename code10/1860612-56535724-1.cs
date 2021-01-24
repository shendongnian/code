    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection("Server=Your_Server_Name;Database=AdventureWorksLT2012;Trusted_Connection=True"); 
                
                try
                {
                    cmd = new SqlCommand("select * from student where sid=@a", con);
                    cmd.Parameters.AddWithValue("@a",int.Parse(comboBox1.SelectedItem.ToString()));
                    con.Open();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            textBox1.Text = dr["sid"].ToString();
                            textBox2.Text = dr["fname"].ToString();
                            textBox3.Text = dr["lname"].ToString();
                            //label1.Text = dr["cdate"].ToString();
                        }
                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
