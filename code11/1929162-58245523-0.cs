    private void newBtn_Click(object sender, EventArgs e)
            {  
                //No Need : Check_Item();         
                SqlCommand cmd = new SqlCommand(); 
                con = new SqlConnection(cs);
                cmd.Connection = con;
                cmd.CommandText = "IF NOT EXISTS(select * from tbl_list where Label = '" + lblBox.Text + "') begin INSERT INTO tbl_list(Label) VALUES('" + lblBox.Text + "') end";
                try
                {
                    con.Open();
    
                    int affected=cmd.ExecuteNonQuery();
                    if (affected > 0)
                    {
                        MessageBox.Show("New Data Added Successfully",
                                  "Notice",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate Data",
                                  "Notice",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    }
                }
                catch(SqlException err)
                {
                    MessageBox.Show(err.Message,
                             "Error",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }           
              
                clearEditTab();
            }
