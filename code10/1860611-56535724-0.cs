    private void button1_Click(object sender, EventArgs e)
            {
                SqlConnection con = new SqlConnection("Server=Your_Server_Name;Database=AdventureWorksLT2012;Trusted_Connection=True"); 
                
                try
                {
                    cmd = new SqlCommand("insert into [dbo].[Student] values(@a,@b,@c)", con);
                    cmd.Parameters.AddWithValue("@a", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@b", textBox2.Text);
                    cmd.Parameters.AddWithValue("@c", textBox3.Text);
                    con.Open();
                    a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Data Submited");
                    }
    
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
