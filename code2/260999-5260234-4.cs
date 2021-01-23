    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    namespace SO {
        class Program {
            static void Main(string[] args) {
                var doc1 = XDocument.Parse(xmlstr);
                var groups = doc1.Root.Elements().ToLookup(page => page.Attribute("PageID").Value);
                var doc2 = new XDocument(new XElement("root"));
                foreach (var group in groups) {
                    var firstpage = group.First();
                    var startindex = firstpage.Elements("Para").Last().Attribute("ParaID").Value;
                    var lastindex = int.Parse(Regex.Match(startindex, @"\d+").Value);
                    // Duplicate pages...
                    firstpage.Add(
                        group.Skip(1)
                             .SelectMany(page => page.Elements("Para"))
                             .Select(
                                 para => {
                                     para.Attribute("ParaID").Value = Regex.Replace(
                                         para.Attribute("ParaID").Value,
                                         @"\d+",
                                         m => (++lastindex).ToString()
                                     );
                                     return para;
                                 }
                             )
                    );
                    doc2.Root.Add(firstpage);
                }
                Console.WriteLine(doc2);
                Console.ReadKey(true);
            }
        }
    }
