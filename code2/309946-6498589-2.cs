    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            private static void Main()
            {
                TimeSpan firstRead = new TimeSpan();
                TimeSpan readerOpen = new TimeSpan();
                TimeSpan commandOpen = new TimeSpan();
                TimeSpan connectionOpen = new TimeSpan();
                TimeSpan secondRead = new TimeSpan();
                
                try
                {
    
                    Stopwatch sw1 = new Stopwatch();
                    sw1.Start();
                    using (
                        var conn =
                            new SqlConnection(
                                @"Data Source=.\sql2k8r2;Initial Catalog=HugeDatabase;Integrated Security=True"))
                    {
                        conn.Open(); connectionOpen = sw1.Elapsed;
    
                        using (var cmd = new SqlCommand(
                            "SELECT * FROM HugeTable ORDER BY PointInTime", conn))
                        {
                            commandOpen = sw1.Elapsed;
    
                            var reader = cmd.ExecuteReader(); readerOpen = sw1.Elapsed;
    
                            reader.Read(); firstRead = sw1.Elapsed;
                            reader.Read(); secondRead = sw1.Elapsed;
                        }
                    }
                    sw1.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
    
                    Console.WriteLine(
                        "Connection: {0}, command: {1}, reader: {2}, read: {3}, second read: {4}",
                        connectionOpen,
                        commandOpen - connectionOpen,
                        readerOpen - commandOpen,
                        firstRead - readerOpen,
                        secondRead - firstRead);
    
                    Console.Write("Enter to exit: ");
                    Console.ReadLine();
                }
            }
        }
    }
