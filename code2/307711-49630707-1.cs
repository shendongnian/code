    String queryForUpdateCustomer = "UPDATE  customer SET cbalance=@txtcustomerblnc WHERE cname='" + searchLookUpEdit1.Text + "'";
                try
                {
                    using (SqlCommand command = new SqlCommand(queryForUpdateCustomer, con))
                    {
                   
                    command.Parameters.AddWithValue("@txtcustomerblnc", txtcustomerblnc.Text);
                    con.Open();
                    int result = command.ExecuteNonQuery();
                    // Check Error
                    if (result < 0)
                        MessageBox.Show("Error");
                    MessageBox.Show("Record Update of Customer...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    loader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
