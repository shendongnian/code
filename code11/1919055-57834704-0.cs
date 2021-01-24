    using System;
    using System.Collections.Generic;
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
                ApiResponse apiResponse = new ApiResponse(FILENAME);
            }
        }
        public class ApiResponse
        {
            public int code { get; set; }
            public string message { get; set; }
            public string _type { get; set; }
            public int count { get; set; }
            public Dictionary<string, Dictionary<string, string>> dict { get; set; }
            public ApiResponse(string filename)
            {
                XDocument doc = XDocument.Load(filename);
                XElement response = doc.Root;
                code = (int)response.Element("Code");
                message = (string)response.Element("Message");
                XElement types = (XElement)response.Element("Data").FirstNode;
                _type = types.Name.LocalName;
                count = (int)types.Element("Count");
                dict = types.Elements().Where(x => x.Name.LocalName != "Count")
                    .GroupBy(x => (string)x.Element("Name"), y => y.Elements()
                        .GroupBy(a => a.Name.LocalName, b => (string)b)
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
