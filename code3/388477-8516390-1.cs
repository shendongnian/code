      protected void ddlUrDropdown_SelectedIndexChanged(object sender, EventArgs e)
      {
            // Checking whether first Item "Select......." (index = 0) is selected or not.
            if (ddlUrDropdown.SelectedIndex != 0)
            {
                // Getting the Selected "Country_Id".
                string keyName = ddlUrDropdown.SelectedValue;
                string connectionString = ConfigurationSettings.AppSettings["keyName"];
                // Where keyName can take values like- "sampleconnectionstring" or "sampleconnectionstring1" or "sampleconnectionstring2" or "sampleconnectionstring3"
                // After getting the connection string according to selected item of combo box, u can create connection and do whatever u want, like below...
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                      connection.Open();
                      // perform work with connection
                 }         
            }
            // Error Message displayed when first Item "Select......." (index = 0) is selected.
            else
            {
                lblError.Text = "Select any item .";
            }
        }      
