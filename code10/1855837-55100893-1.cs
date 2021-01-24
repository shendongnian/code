    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication104
    {
        class Program
        {
            static void Main(string[] args)
            {
                string oldFileName = "C:\\AlertReportTill.csv";
                string newFileName = string.Format("C:\\AlertReportTill_{0}.csv", DateTime.Now.ToString("yyyyMMdd_hhmmss"));
                StreamReader reader = new StreamReader(oldFileName);
                if (!System.IO.File.Exists(newFileName))
                {
                    StreamWriter writer = new StreamWriter(newFileName);
                    writer.WriteLine("Weekly Report");
                    string AlertHeader = string.Join(",", new string[] 
                       {"WeeklyReport",
                        "ColumnHeader1", "ColumnHeader2", "ColumnHeader3"
                       });
                    writer.WriteLine(AlertHeader);
                    string line = "";
                    int RowCount = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        List<string> AlertDetails = line.Split(new char[] { ',' }).ToList();
                        AlertDetails.Insert(0, "RowHeader" + ++RowCount);
                        writer.WriteLine(string.Join(",", AlertDetails));
                    }
                    reader.Close();
                    writer.Flush();
                    writer.Close();
                } //End of If Statement
            }
        }
    }
