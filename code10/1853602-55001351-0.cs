    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication103
    {
        class Program
        {
            const string INPUT_XML = @"c:\temp\test.xml";
            const string OUTPUT_CSV = @"c:\temp\test.csv";
            const string INPUT_CSV = @"c:\temp\test2.csv";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(INPUT_XML);
                var colorsWithDuplicates = doc.Descendants("namespace")
                    .SelectMany(ns => ns.Elements()
                    .SelectMany(color => color.Elements().Select(y => new {color = color.Name.LocalName,  language = y.Name.LocalName, value = (string)y}))
                    ).ToList();
                var colors = colorsWithDuplicates.GroupBy(x => new object[] { x.color, x.language }).Select(x => x.First()).ToList();
                var sortedAndGrouped = colors.OrderBy(x => x.language).ThenBy(x => x.color).GroupBy(x => x.color).ToList();
                List<string> countries = sortedAndGrouped.FirstOrDefault().Select(x => x.language).ToList();
                StreamWriter writer = new StreamWriter(OUTPUT_CSV, false, Encoding.Unicode);
                writer.WriteLine(string.Join(",",countries));
                foreach (var color in sortedAndGrouped)
                {
                    writer.WriteLine(string.Join(";",color.Select(x => x.value)));
                }
                writer.Flush();
                writer.Close();
                StreamReader reader = new StreamReader(INPUT_CSV);
                List<string> newCountries = reader.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string line = "";
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    List<string> splitLine = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    dict.Add(splitLine[0], splitLine);
                }
                //now replace colors
                foreach (XElement xNs in doc.Descendants("namespace"))
                {
                    foreach (XElement xColor in xNs.Elements())
                    {
                        
                        string checkColor = xColor.Name.LocalName;
                        checkColor = char.ToUpper(checkColor[0]) + checkColor.Substring(1);
                        List<string> inputColors = dict[checkColor];
                        for (int index = 0; index < inputColors.Count; index++)
                        {
                            XElement colorElement = xColor.Element(inputColors[index]);
                            if (colorElement == null)
                            {
                                xColor.Add(new XElement(newCountries[index], inputColors[index]));
                            }
                        }
                    }
                }
            }
        }
     
    }
