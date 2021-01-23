    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(SqlServerIsRunning("Server=foobar; Database=tempdb; Integrated Security=true", 5));
            Console.WriteLine(SqlServerIsRunning("Server=localhost; Database=tempdb; Integrated Security=true", 5));
        }
        private static bool SqlServerIsRunning(string baseConnectionString, int timeoutInSeconds)
        {
            bool result;
            using (SqlConnection sqlConnection = new SqlConnection(baseConnectionString + ";Connection Timeout=" + timeoutInSeconds))
            {
                Thread thread = new Thread(TryOpen);
                ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                thread.Start(new Tuple<SqlConnection, ManualResetEvent>(sqlConnection, manualResetEvent));
                result = manualResetEvent.WaitOne(timeoutInSeconds*1000);
                if (!result)
                {
                    thread.Abort();
                }
                sqlConnection.Close();
            }
            return result;
        }
        private static void TryOpen(object input)
        {
            Tuple<SqlConnection, ManualResetEvent> parameters = (Tuple<SqlConnection, ManualResetEvent>)input;
            try
            {
                parameters.Item1.Open();
                parameters.Item1.Close();
                parameters.Item2.Set();
            }
            catch
            {
                // Eat any exception, we're not interested in it
            }
        }
    }
