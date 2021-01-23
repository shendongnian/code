        static void Main(string[] args)
        {
            string conStr = "Integrated Security=true;Initial Catalog=sushma;server=(local)";
            SqlConnection sqlConnection = new SqlConnection(conStr);
            sqlConnection.Open();
            SqlCommand DbCommand = new SqlCommand("CREATE TABLE dbo.#temp (id INT);", sqlConnection);
            DbCommand.ExecuteNonQuery();
            SqlTransaction transaction = sqlConnection.BeginTransaction();
            DbCommand.CommandText = "SELECT * FROM dbo.#temp";
            DbCommand.Transaction = transaction;
            SqlDataReader dr = DbCommand.ExecuteReader();
            dr.Close();            
            transaction.Commit();
            Console.WriteLine("what is the issue");
            Console.ReadKey();
        }
