    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace TestProgram
    {
        static class Program
        {
            // NET4 has this in System.IO.File
            private static IEnumerable<string> ReadAllLines(string fname)
            {
                using (var r = new StreamReader(fname))
                {
                    var line = r.ReadLine();
                    while (null != line)
                    {
                        yield return line;
                        line = r.ReadLine();
                    }
                }
            }
    
            private static string[] CsvFields(string line, char[] delim)
            {
                return null==line 
                    ? null 
                    : line.Split(delim, StringSplitOptions.None);
            }
    
            public static IEnumerable<T> ProjectCsv<T>(this IEnumerable<string> lines, char[] delim, Func<string[], T> projection)
            {
                return lines.Select(l => projection(CsvFields(l, delim)));
            }
    
            public static IEnumerable<T> ProjectCsv<T>(this IEnumerable<string> lines, char[] delim, Func<string[], int, T> projection)
            {
                return lines.Select((l, i) => projection(CsvFields(l, delim), i));
            }
    
            static void Main(string[] args)
            {
                foreach (var filename in args)
                {
                    var csv = ReadAllLines(filename);
    
                    var delimiter = new[] { '\t' };
                    var headers = CsvFields(csv.First(), delimiter);
    
                    Console.WriteLine(
                        new XDocument(new XElement("CSV",
                            new XAttribute("source", filename),
                            csv.ProjectCsv(delimiter, (fields, linenum) =>
                                new XElement("Line",
                                    new XAttribute("number", linenum),
                                    headers.Select((caption, index) => new XElement(caption, new XText(fields[index])))
                        ))))
                    );
                }
    
                Console.WriteLine("Done, press a key");
                Console.ReadKey();
            }
        }
    }
