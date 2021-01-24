    using System;
    using System.Data;
    using System.Xml.Linq;
    
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Date", typeof(DateTime));
                dt.Columns.Add("Severity", typeof(string));
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Msg", typeof(string));
    
                XDocument docLog = XDocument.Load("test.xml");
    
                foreach (XElement log in docLog.Descendants("Log"))
                {
    
                    DateTime date = (DateTime)log.Attribute("Date");
                    string severity = (string)log.Attribute("Severity");
                    string id = (string)log.Attribute("id");
                    string ID = (string)log.Attribute("ID");
                    string msg = (string)log.Attribute("Msg");
    
                    dt.Rows.Add(new object[] { date, severity, id, ID, msg });
                }
                foreach (DataRow dataRow in dt.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.WriteLine(item);
                        
                    }
                }
                Console.ReadLine();
            }
        }
    }
