        static void Main(string[] args)
        {
            GetData();
        }
        public static void GetData()
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["main"].ConnectionString);
            conn.Open();
            string query = "SELECT FileStream FROM [EventOne] Where  ID=2";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            byte[] buffer = dt.AsEnumerable().Select(c => c.Field<byte[]>("FileStream")).SingleOrDefault();
            File.WriteAllBytes("c:\\FileStream.txt", buffer);
        }
