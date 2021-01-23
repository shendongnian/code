    class Program
    {
        static void Main(string[] args)
        {
            OracleConnection conn = null;
            try
            {
                const string connString = "DATA SOURCE=XE;PERSIST SECURITY INFO=True;USER ID=HR;PASSWORD=Adv41722";
                conn = new OracleConnection(connString);
                conn.Open();
                var p = new DynamicParameters();
                p.Add(":dep_id", 60);
                p.Add(":employees_c", dbType: DbType.Object, direction: ParameterDirection.Output);
                p.Add(":departments_c", dbType: DbType.Object, direction: ParameterDirection.Output);
                // This will return an IEnumerable<Employee> // How do I return both result?
                var results = conn.Query<Employee>("HR_DATA.GETCURSORS", p, commandType: CommandType.StoredProcedure);
      
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }                
            }
            Console.WriteLine("Fininhed!");
            Console.ReadLine();
        }
    }
    class Employee
    {
        public int Employee_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE_NUMBER { get; set; }
    }
