    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication3
    {
        class Program1
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string line = "";
                int rowCount = 0;
                StreamReader reader = new StreamReader(FILENAME);
                string pattern = @"^(?'time'.*):\[(?'systemid'[^\]]+)\]:(?'sending'[^:]+):(?'receiving'[^:]+):(?'length'[^:]+):(?'data'[^:]+):\[(?'ws_name'[^\]]+)\]";
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0)
                    {
                        if (++rowCount != 1) //skip header row
                        {
                            Log_Data newRow = new Log_Data();
                            Log_Data.logData.Add(newRow);
                            Match match = Regex.Match(line, pattern, RegexOptions.RightToLeft);
                            newRow.ws_name = match.Groups["ws_name"].Value;
                            newRow.data = match.Groups["data"].Value;
                            newRow.length = int.Parse(match.Groups["length"].Value);
                            newRow.receiving_system = match.Groups["receiving"].Value;
                            newRow.sending_system = match.Groups["sending"].Value;
                            newRow.systemid  = match.Groups["systemid"].Value;
                            //end data is first then start date is second
                            string[] date = match.Groups["time"].Value.Split(new char[] {'|'}).ToArray();
                            string replacePattern = @"(?'leader'.+):(?'trailer'\d+)";
                            string stringDate = Regex.Replace(date[1], replacePattern, "${leader}.${trailer}", RegexOptions.RightToLeft);
                            newRow.startDate = DateTime.Parse(stringDate);
                            stringDate = Regex.Replace(date[0], replacePattern, "${leader}.${trailer}", RegexOptions.RightToLeft);
                            newRow.endDate = DateTime.Parse(stringDate );
                        }
                    }
                }
     
            }
        }
        public class Log_Data
        {
            public static List<Log_Data> logData = new List<Log_Data>();
            public DateTime startDate { get; set; } //transaction_date_time:[systemid]:sending_system:receiving_system:data_length:data:[ws_name]
            public DateTime endDate { get; set; }
            public string systemid { get; set; }
            public string sending_system { get; set; }
            public string receiving_system { get; set; }
            public int length { get; set; }
            public string data { get; set; }
            public string ws_name { get; set; }
        }
    }
     
