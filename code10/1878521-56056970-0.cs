    using (SqlConnection con = new SqlConnection("connectionstring"))
            {
                foreach (DataRow dr in worksheetTable.Rows)
                {
                    try
                    {
                        con.Open();
                        SqlCommand myCommand = new SqlCommand("insert into myTable (Products, column2) values (@prod, @col2)", con);
                        myCommand.CommandType = CommandType.Text;
                        myCommand.Parameters.AddWithValue("prod", dr[0]);
                        myCommand.Parameters.AddWithValue("col2", dr[1]);
                        int result = myCommand.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        //handle errors here
                    }
                    catch (Exception ex)
                    {
                        //handle errors here
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
