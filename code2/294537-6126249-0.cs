    static string BuildEntityConnString(string dbFileName, string resourceData, string password) {
      string resAll = @"res://*/";
      string dataSource = @"Data Source=|DataDirectory|\" + dbFileName;
      EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
      entityBuilder.Metadata = string.Format("{0}{1}.csdl|{0}{1}.ssdl|{0}{1}.msl", resAll, resourceData);
      entityBuilder.Provider = "System.Data.SqlServerCe.3.5";
      if (String.IsNullOrEmpty(password)) {
        entityBuilder.ProviderConnectionString = dataSource;
      } else {
        entityBuilder.ProviderConnectionString = dataSource + ";Password=" + password;
      }
      using (EntityConnection con = new EntityConnection()) {
        try {
          con.ConnectionString = entityBuilder.ToString();
          con.Open();
          Console.WriteLine("{0} Entity String created.", dbFileName);
          con.Close();
          return con.ConnectionString;
        } catch (Exception err) {
          Console.WriteLine(err);
        }
      }
      return null;
    }
