     using (var conn = new SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=aspnetdb;Integrated Security=True;Connect Timeout=30;User Instance=True"))
                {
    
                    conn.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Customer (Name,SIC_NAIC) VALUES (@Name,@SIC_NAIC)",conn))
                    {
                        try
                        {
                            cmd.Parameters.Add("@Name", SQlDbType.VarChar, 50).Value = TextBox1.Text;
                            cmd.Parameters.Add("@SIC_NAIC", SQlDbType.VarChar, 50).Value = RadioButtonList1.SelecedItem.ToString();
                           
    
    
                            cmd.ExecuteNonQuery();
        
                            
                        }
                        catch (Exception)
                        {
                            {
                                                          }
    
                            throw;
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open) conn.Close();
                        }
                    }
