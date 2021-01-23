    // .NET DataProvider -- Standard Connection  
    
    using System.Data.SqlClient;
    
    SqlConnection conn = new SqlDbConnection();
    conn.ConnectionString = 
                  "Data Source=ServerName;" + 
                  "Initial Catalog=DataBaseName;" + 
                  "User id=UserName;" + 
                  "Password=Secret;"; //change to fit your case
    conn.Open();
    
     
    
     
