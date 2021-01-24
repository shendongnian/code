    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string line = "";
                Report report = new Report();
                string header = "";
                while ((line = reader.ReadLine()) != null)
                {
                    List<string> data = new List<string>();
                    string[] row = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (row.Length > 0)
                    {
                        if (line.StartsWith(","))
                        {
                            data = row.ToList();
                        }
                        else
                        {
                            header = row[0];
                            data = row.Skip(1).ToList();
                        }
                        if (data.Count == 0) continue;
                        switch (header)
                        {
                            case "REPORT TITLE":
                                report.title = data[0];
                                break;
                            case "REPORT DESCRIPTION":
                                report.description = data[0];
                                break;
                            case "GENERATED":
                                report.generated = data[0];
                                break;
                            case "Client Name":
                                report.name = data[0];
                                break;
                            case "Time Frame":
                                if (report.timeFrame == null) report.timeFrame = new List<string>();
                                report.timeFrame.AddRange(data);
                                break;
                            case "Received Date":
                                if (report.receivedDate == null) report.receivedDate = new List<string>();
                                report.receivedDate.AddRange(data);
                                break;
                            case "Service Date":
                                if (report.serviceDate == null) report.serviceDate = new List<string>();
                                report.serviceDate.AddRange(data);
                                break;
                            case "Adjustments":
                                if (report.adjustments == null) report.adjustments = new List<string>();
                                report.adjustments.AddRange(data);
                                break;
                            case "View":
                                if (report.view == null) report.view = new List<string>();
                                report.view.AddRange(data);
                                break;
                            case "SERVICE LINE":
                                if (report.serviceLine == null) report.serviceLine = new List<string>();
                                report.serviceLine.AddRange(data);
                                break;
                            case "SITE":
                                if (report.site == null) report.site = new List<string>();
                                report.site.AddRange(data);
                                break;
                            case "FILTER":
                                if (report.filter == null) report.filter = new List<string>();
                                report.filter.AddRange(data);
                                break;
                            case "Client ID":
                                if (report.clientId == null) report.clientId = new List<string>();
                                report.clientId.AddRange(data);
                                break;
                        }
                    }
                }
            }
        }
        public class Report
        {
            public string title { get; set; }
            public string description { get; set; }
            public string  generated { get; set; }
            public string name { get; set; }
            public List<string> timeFrame { get; set; }
            public List<string> receivedDate { get; set; }
            public List<string> serviceDate { get; set; }
            public List<string> adjustments { get; set; }
            public List<string> view { get; set; }
            public List<string> serviceLine { get; set; }
            public List<string> site { get; set; }
            public List<string> filter { get; set; }
            public List<string> clientId { get; set; }
        }
    }
