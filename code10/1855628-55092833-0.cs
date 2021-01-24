        protected void Delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString))
            {
                string delete = "DELETE FROM Contact WHERE Name = @Name;"; //no single quotes to worry about
                using (SqlCommand cmd = new SqlCommand(delete, con))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = NameToDelete.Text; //just guessed at the VarChar - check your database for type
                    try                  
                    {           
                        con.Open();
                        cmd.ExecuteNonQuery();
                        Response.Redirect("ViewContacts.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message); //ex by itself, will get you nothing but the fully qualified name of Exception
                    }
                }
            }
        }
