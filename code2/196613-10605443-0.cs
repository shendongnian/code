    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo.Agent;
    
    namespace SmoTest
    {
    class Program
    {
        static readonly string SqlServer = @"SQL01\SQL01";
        static void Main(string[] args)
        {
            ServerConnection conn = new ServerConnection(SqlServer);
            Server server = new Server(conn);
            JobCollection jobs = server.JobServer.Jobs;
            foreach (Job job in jobs)
            {
                Console.WriteLine(job.Name);
            }
        }
    }
}
