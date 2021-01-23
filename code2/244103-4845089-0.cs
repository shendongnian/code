     private System.Object uploadLock = new System.Object();
    
     private void uploadDatabase(string company, string oldCompany, string companyURL, string loginUsername, string oldUsername, string password, string type, string perform, string direction)
            {
                lock(uploadLock ) {
                Boolean recordFound = false;
                recordFound = checkRecordNotExist(company, loginUsername);
                MySQLDBWork dbase = new MySQLDBWork();
                try
                {
                    dbase.openConnection();
                    if (perform == "insert" && !recordFound)
                    {
                        string query = "INSERT INTO `" + username + "` (pas_company, pas_companyURL, pas_username, pas_password, pas_type) "
                            + "VALUES ('" + company + "', '" + companyURL + "', '" + loginUsername + "', '" + password + "', '" + type + "')";
                        Console.WriteLine("Query: " + query);
                        MySqlCommand cmd = new MySqlCommand(query, dbase.conn);
                        cmd.ExecuteNonQuery();
                        recordFound = true;
                        query = "";
                        company = "";
                        loginUsername = "";
                        cmd.Dispose();
                    }
                    if (perform == "delete")
                    {
                        string query = "DELETE FROM `" + username + "` WHERE pas_company='" + company + "' AND pas_username='" + loginUsername + "'";
                        dbase.performQuery(query);
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Adding Online Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Exception: " + ex.Message);
                }
                finally
                {
                    dbase.closeConnection();
                    //dbase.conn.Dispose();
                    company = null;
                    loginUsername = null;
                }
            }
    }
