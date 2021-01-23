    namespace ConsoleApplication15
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("success");
    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error Due To :" + e.Message);
                }
                finally
                {
                    //code for opening the second console....(is that passible)
                    System.Diagnostics.Process.Start("ConsoleApplication15.exe");
                }
    
            }
        }
    }
