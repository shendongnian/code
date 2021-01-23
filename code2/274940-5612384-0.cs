     System.Configuration.Configuration updateWebConfig =
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("\\");
     System.Configuration.ConnectionStringSettings conStringSettings = updateWebConfig.ConnectionStrings.ConnectionStrings["testConString"]; //your connection string name here as specified in the web.Config file
     conStringSettings.ConnectionString = txtCon.Text; //Your Textbox value here
     conStringSettings.CurrentConfiguration.Save();
