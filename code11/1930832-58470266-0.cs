    using System.Data.SqlClient;
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString =
        "Data Source=ServerName;" +
        "Initial Catalog=DataBaseName;" +
        "User id=" + UserName + ";"
        "Password=" + Password + ";";
     conn.Open();
