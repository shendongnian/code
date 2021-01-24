    class myConnection
    {
        public static SqlConnection GetConnection(string UserName, string Password)
        {
            string str = "Data Source=ServerName;Initial Catalog=DataBaseName;User id=" +             
            UserName + ";Password=" + Password + ";";
            SQlConnection con = new SqlConnection(str);
            con.Open();
            return con;
        }
    }
