    <appSettings>
    <add key="strConnectionString" value="Data Source=YourDomain\ServerName;
        Initial Catalog=yourDatabaseNameP;User ID=YourUser;Trusted_Connection=yes"/>
    </appSettings>
    // .NET DataProvider -- Trusted Connection  
    
    using System.Data.SqlClient;
    
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = 
                  "Data Source=ServerName;" + 
                  "Initial Catalog=DataBaseName;" + 
                  "Integrated Security=SSPI;"; 
    conn.Open();
