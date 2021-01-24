    using System; 
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
    using System.Xml; 
    using System.Xml.Linq;
    using System.Data;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Topic Name", typeof(string));
                dt.Columns.Add("Manual", typeof(string));
                dt.Columns.Add("Project", typeof(string));
                dt.Columns.Add("Document", typeof(string));
                dt.Columns.Add("HREF", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                string pattern = "href=\"(?'href'[^\"]+)\">(?'innertext'[^<]+)";
                foreach (XElement topic in doc.Descendants("topic"))
                {
                    string name = (string)topic.Element("name");
                    string manual = string.Join(",", topic.Elements("manual").Select(x => ((string)x).Trim()));
                    string project = string.Join(",",topic.Elements("project").Select(x => ((string)x).Trim()));
                    XElement document = topic.Element("document");
                    string items = document.Value;
                    MatchCollection matches = Regex.Matches(items, pattern);
                    foreach (Match match in matches)
                    {
                        dt.Rows.Add(new object[] {
                            name,
                            manual,
                            project,
                            match.Groups["innertext"].Value,
                            match.Groups["href"].Value
                        });
                    }
                }
            }
        }
    }
