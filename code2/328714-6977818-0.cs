       private string GetWebConfigConnection()
        {
            string conString = string.Empty;
            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/WebSite21"); // give your web site name here
            
            System.Configuration.ConnectionStringSettings connString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString = rootWebConfig.ConnectionStrings.ConnectionStrings["MainConnStr"]; // give your connection string name here
                if (connString != null)
                    conString=  connString.ConnectionString;
            }
            return conString;
        }
