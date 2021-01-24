    using CsvHelper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace ConsoleApp5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var records = new List<Foo>
                {
                    new Foo { Id = 1, Name = "one" },
                };
    
                var configuration = new CsvHelper.Configuration.Configuration()
                {
                    Delimiter = "\t"
                };
    
                using (var writer = new StreamWriter("path\\to\\file.csv"))
                using (var csv = new CsvWriter(writer, configuration))
                {
                    csv.WriteRecords(records);
                }
            }
    
            public class Foo
            {
                public int Id { get; set; }
                public string Name { get; set; }
            }
        }
    }
