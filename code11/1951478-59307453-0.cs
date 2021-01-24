    using System;
    using Kusto.Data;
    
    namespace hello_world
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                var client = Kusto.Data.Net.Client.KustoClientFactory.CreateCslQueryProvider("https://help.kusto.windows.net/Samples;Fed=true");
                var reader = client.ExecuteQuery("StormEvents | sort by StartTime desc | take 10");
    
            }
        }
    }
