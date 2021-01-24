     static SqlHandle ()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ParkingMaster.Properties.Settings.Setting"].ToString());
            try
            {
                connection.Open();
                MessageBox.Show("Connection opened!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }  
        }
