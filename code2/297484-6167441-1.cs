         string strConnection = ConfigurationSettings.AppSettings["ConnectionString"];
         MySqlConnection connection = new MySqlConnection(strConnection);
         List<string> array = new List<string>();
            using (MySqlCommand cmd = new MySqlCommand("SELECT idprojects FROM `test`.`projects` WHERE application_layers = " + applicationTiers, connection))
            {
                try
                {
                    using (MySqlDataReader Reader = cmd.ExecuteReader())
                    {
                        while (Reader.Read())
                        {
                            array.Add(Reader["idprojects"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            string[] ret= array.ToArray();
