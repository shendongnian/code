    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    namespace DbmlSorter
    {
        class Program
        {
            static void Main(string[] args)
            {
                if (args.Length == 0)
                    return;
                var fileName = args[0];
                try
                {
                    if (!File.Exists(fileName))
                        return;
                    SortElements(fileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            private static void SortElements(string fileName)
            {
                var root        = XElement.Load(fileName);
                var connections = new SortedDictionary<string, XElement>();
                var tables      = new SortedDictionary<string, XElement>();
                var functions   = new SortedDictionary<string, XElement>();
                var others      = new SortedDictionary<string, XElement>();
                foreach (var element in root.Elements())
                {
                    var key = element.ToString();
                    if (key.StartsWith("<Connection"))
                        connections.Add(key, element);
                    else if (key.StartsWith("<Table"))
                        tables.Add(key, element);
                    else if (key.StartsWith("<Function"))
                        functions.Add(key, element);
                    else
                        others.Add(key, element);
                }
                root.RemoveNodes();
                foreach (var pair in connections)
                {
                    root.Add(pair.Value);
                    Console.WriteLine(pair.Key);
                }
                foreach (var pair in tables)
                {
                    root.Add(pair.Value);
                    Console.WriteLine(pair.Key);
                }
                foreach (var pair in functions)
                {
                    root.Add(pair.Value);
                    Console.WriteLine(pair.Key);
                }
                foreach (var pair in others)
                {
                    root.Add(pair.Value);
                    Console.WriteLine(pair.Key);
                }
                root.Save(fileName);
            }
        }
    }
