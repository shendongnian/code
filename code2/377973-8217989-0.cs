    public class Program
    {
        private static void Main(string[] args)
        {
            using (var trx = new TransactionScope())
            {
                InitializeData();
    
                using (var connection = new SqlConnection("server=localhost;database=Test;integrated security=true"))
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select count(*) from MyTable";
                    connection.Open();
                    Console.WriteLine("{0} rows", command.ExecuteScalar());
                }
            }
            Console.ReadLine();
        }
    
        private static void InitializeData()
        {
            using (var connection = new SqlConnection("server=localhost;database=Test;integrated security=true"))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into MyTable values (1),(2),(3)";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
