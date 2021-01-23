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
                var cmd = new OracleCommand("HR_DATA.GETCURSORS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                var dep_id = new OracleParameter();
                dep_id.OracleDbType = OracleDbType.Decimal;
                dep_id.Direction = ParameterDirection.Input;
                dep_id.Value = 60;
                cmd.Parameters.Add(dep_id);
                var employees_c = new OracleParameter();
                employees_c.OracleDbType = OracleDbType.RefCursor;
                employees_c.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(employees_c);
                var departments_c = new OracleParameter();
                departments_c.OracleDbType = OracleDbType.RefCursor;
                departments_c.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(departments_c);
                cmd.ExecuteNonQuery();
                // Omitted; Do something with results
                var p = new DynamicParameters();
                p.Add(":dep_id", 60);
                p.Add(":employees_c", dbType: DbType.Object, direction: ParameterDirection.Output);
                p.Add(":departments_c", dbType: DbType.Object, direction: ParameterDirection.Output);
                conn.Execute("HR_DATA.GETCURSORS", p, commandType: CommandType.StoredProcedure);
                var b = p.Get<object>(":employees_c");
                var c = p.Get<object>(":departments_c");
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
