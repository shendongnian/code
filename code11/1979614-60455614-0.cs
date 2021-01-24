    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication159
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                string dataStr = (string)doc.Descendants("data").FirstOrDefault();
                int[][] results = dataStr.Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray()).ToArray();
            }
        }
    }
