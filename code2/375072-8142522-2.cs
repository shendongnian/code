    public abstract class Stats
    {
        // put your fields here
        public bool Exists { get; set; }
        public int Count { get; set; }
        public Frob Foo { get; set; }
        public abstract void Fill(string procedureName)
        {
            SqlConnection connection = new SqlConnection("Get your own connection string");
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = procedureName; // your query may be more complicated than this?
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                this.Count = (int)reader["Count"];
            }
        }
    }
