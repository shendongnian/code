    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Dapper;
    
    
    namespace ConsoleApp26
    {
        class Customer
        {
            public string CustomerName { get; set; }
        }
        class Program
        {
            private object _customersNoAction;
    
            public async Task ProcessFileAsync(Stream blobFile)
            {
                List<Customer> customers = Enumerable.Range(1, 1000).Select(i => new Customer() { CustomerName = $"Customer{i}" } ).ToList();
                var tasks = RunWithMaxDegreeOfConcurrency(100, customers, customer => VerifyCustomerAsync(customer));
                await Task.WhenAll(tasks);
    
                DoStuffWhenAllDatabaseCallsAreFinished();
            }
    
            private void DoStuffWhenAllDatabaseCallsAreFinished()
            {
                RecordLog(LogType.Info, $"Finished");
            }
    
            private async Task VerifyCustomerAsync(Customer customer)
            {
                RecordLog(LogType.Info, $"Starting {customer.CustomerName}");
    
                var parameters = new DynamicParameters();
                // ... create parameters 
    
                ValidaitonResult validaitonResult = null;
                using (var connection = new SqlConnection("server=.;database=tempdb;integrated security=true"))
                {
                    connection.Open();
                    //var queryResult = await connection.QueryAsync<ValidaitonResult>("sp_name", parameters, commandType: CommandType.StoredProcedure);
    
                    var queryResult = await connection.QueryAsync<ValidaitonResult>("waitfor delay '0:0:2'; select 1 ValidationAction");
                    validaitonResult = queryResult.FirstOrDefault();
                }
    
                // Handle the result
    
                RecordLog(LogType.Info, $"--Finished {customer.CustomerName}");
            }
    
            private void RecordLog(object info, string v)
            {
                Console.WriteLine($"{v}running on thread {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            }
    
            private static async Task RunWithMaxDegreeOfConcurrency<T>(int maxDegreeOfConcurrency, IEnumerable<T> collection, Func<T, Task> taskFactory)
            {
                var activeTasks = new List<Task>(maxDegreeOfConcurrency);
                foreach (var task in collection.Select(taskFactory))
                {
                    activeTasks.Add(task);
                    if (activeTasks.Count == maxDegreeOfConcurrency)
                    {
                        await Task.WhenAny(activeTasks.ToArray());
    
                        foreach (var t in activeTasks)
                        {
                            if (t.IsFaulted)
                                throw t.Exception;
                        }
                        activeTasks.RemoveAll(t => t.IsCompleted);
                    }
                }
                await Task.WhenAll(activeTasks.ToArray()).ContinueWith(t =>
                {
                    //observe exceptions in a manner consistent with the above   
                });
            }
    
            static void Main(string[] args)
            {
                var p = new Program();
                p.ProcessFileAsync(null).Wait();
            }
    
            private class LogType
            {
                internal static readonly int Info = 1;
            }
        }
    
        internal class ValidaitonResult
        {
            public int ValidaitonAction { get; internal set; }
        }
    }
