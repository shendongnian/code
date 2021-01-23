            string conString = ConfigurationManager.ConnectionStrings["sqlCEConnectionString"].ConnectionString;
        using (SqlCeEngine objCeEngine = new SqlCeEngine(conString))
        {
            if (!objCeEngine.Verify())
            {
                objCeEngine.CreateDatabase();
            }
        }
