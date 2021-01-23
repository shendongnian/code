    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Due To: " + ex.Message);
            }
            finally
            {
                //code for opening the second console....(is that passible)
                System.Diagnostics.Process.Start("ConsoleApplication15.exe");
            }
        }
    }
