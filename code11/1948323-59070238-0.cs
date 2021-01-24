    sing System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
             static void Main(string[] args)
             {
                 DataTable dt = new DataTable();
                 dt.Columns.Add("IP", typeof(string));
                 string pattern = "Data Source=(?'ip'[^;]+)";
                 foreach (DataRow row in dt.AsEnumerable())
                 {
                     string connectString = row.Field<string>("ConnectionString");
                     Match match = Regex.Match(connectString, pattern);
                     string ip = match.Groups["ip"].Value;
                     row["IP"] = ip;
                 }
             }
        }
      
    }
