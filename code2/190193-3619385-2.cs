    internal static class Program
    {
        private static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=localhost; Database=tempdb; Integrated Security=true;Connection Timeout=5");
            Console.WriteLine("Attempting to open connection with {0} second timeout, starting at {1}.", con.ConnectionTimeout, DateTime.Now.ToLongTimeString());
            try
            {
                con.Open();
                Console.WriteLine("Successfully opened connection at {0}.", DateTime.Now.ToLongTimeString());
            }
            catch (SqlException)
            {
                Console.WriteLine("SqlException raised at {0}.", DateTime.Now.ToLongTimeString());
            }
        }
    }
