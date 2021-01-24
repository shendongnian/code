        public class SqlSettings
        {
          public string ConnectionString { get; set; }
          public void SetDbName(string companyName)
          {
              int index = ConnectionString.LastIndexOf("=");
              if (index > 0)
                  ConnectionString = ConnectionString.Substring(0, index);
              ConnectionString = $"{ConnectionString}={companyName}";
          }
        }
