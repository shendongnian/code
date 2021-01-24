    private void addRecord()
        {
            try
            {
                string btnClick = CusMsgBox.showBox("SAVE", "Do you want to save record?");
    
                if (btnClick == "1")
                {
                    
                    Using (SqlConnection conn = new SqlConnection(connectionString)) //No idea where your connection string is
                    {
                        Using (SqlCommand cmd = new SqlCommand("SP_InsertBookHeader", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = txtBookID.Text;
                            cmd.Parameters.Add("@Copies", SqlDbType.Int).Value = int.Parse(txtCopies.Text);
                            cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Parse(dtpDate.Value.ToString());
    
                            conn.Open();
                            int line = cmd.ExecuteNonQuery();
                        }
                    }
                    foreach (DataGridViewRow items in dgvBook.Rows)
                    {
                        Using (SqlConnection conn = new SqlConnection(connectionString))    
                        {
                            
                            Using (SqlCommand cmd = new SqlCommand("SP_InsertBookDetail", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = txtBookID.Text;
                                cmd.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = items.Cells["ISBN"].Value.ToString();
                                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = items.Cells["Name"].Value.ToString();
                                cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = items.Cells["Description"].Value.ToString();
                                cmd.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = DateTime.Parse(items.Cells["Publish Date"].Value.ToString());
                                cmd.Parameters.Add("@Language", SqlDbType.VarChar).Value =  items.Cells["Language"].Value.ToString();
                                cmd.Parameters.Add("@AuthorID", SqlDbType.VarChar).Value = items.Cells["Author"].Value.ToString();
                                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = items.Cells["Category"].Value.ToString();
                                cmd.Parameters.Add("@Edition", SqlDbType.Int).Value = int.Parse(items.Cells["Edition"].Value.ToString());
                                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = decimal.Parse(items.Cells["Price"].Value.ToString());
    
                                conn.Open();
                                cmd.ExecuteNonQuery();
    
                            }
                        }
                    
                    }
    
                    if (line > 0)
                    {
                        clearRecord();
                        clearBookRecord();
                        viewBookID();
                        viewBookRecord();
                        CusNotifi.showSuccess("Data Inserted Succesfully!");
                    }
                    else
                    {
                        CusNotifi.showError("Data Insert Failed!");
                    }
                }
                else
                {
                    CusMsgBox cmb = new CusMsgBox();
                    cmb.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
