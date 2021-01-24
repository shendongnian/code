    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<int, List<int>> dict = doc.Descendants("Record")
                    .GroupBy(x => (int)x.Element("ManagerId"), y => (int)y.Element("EmployeeId"))
                    .ToDictionary(x => x.Key, y => y.ToList());
            }
        }
    }
