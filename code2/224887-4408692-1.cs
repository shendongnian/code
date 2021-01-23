        public Form1()
        {
            InitializeComponent();
            String ConnectionString = @"Data Source=SERVER\SQLEXPRESS;Initial Catalog=DBNAME;User ID=USER;Password=PWD";
            StringBuilder sb = new StringBuilder();
            using (SqlConnection sConnection = new SqlConnection(ConnectionString))
            {
                String query = @"SELECT TABLE_NAME AS TABLES FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND TABLE_NAME <> 'dtProperties' ORDER BY TABLE_NAME";
                SqlCommand comand = new SqlCommand(query, sConnection);
                sConnection.Open();
                SqlDataReader reader = comand.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("reader.hasRows == true !");
                }
                else
                {
                    Console.WriteLine("reader.hasRows == FALSE !");
                }
                while (reader.Read())
                {
                    sb.AppendLine(reader.GetString(0));
                }
            }
            Console.WriteLine(sb.ToString());
        }
    }
