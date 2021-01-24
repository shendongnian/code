using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
                    
public class Program
{
    public static void Main()
    {
        var input = new Foo
        {
            Label = "My Foo",
            Bars = new List<Bar> {
                new Bar{Label="Bar2"},
                new Bar{Label="Bar1"},
                new Bar{Label="Bar3"},
            }
        };
        var json = JsonConvert.SerializeObject(input);
        var myObject = new CsvObject
        {
            Label = "My CSV object",
            FooString = json,
        };
        var result = "";
        // Writing into a string instead of a file for debug purpuse. 
        using (var stream = new MemoryStream())
        using (var reader = new StreamReader(stream))
        using (var writer = new StreamWriter(stream))
        using (var csv = new CsvWriter(writer))
        {
            csv.Configuration.RegisterClassMap<CsvObjectMap>();
            csv.WriteHeader<CsvObject>();                
            csv.NextRecord();
            csv.WriteRecord(myObject);                
            csv.NextRecord();
            writer.Flush();
            stream.Position = 0;
            result = reader.ReadToEnd();
        }
        Console.WriteLine(result);
    }
    
    private sealed class CsvObjectMap : ClassMap<CsvObject>
    {
        public CsvObjectMap()
        {
            Map( m => m.FooString );
            Map( m => m.Label );
        }
    }
    public class CsvObject
    {
        public string Label { get; set; }
        public string FooString { get; set; }
    }
    public class Foo
    {
        public string Label { get; set; }
        public List<Bar> Bars { get; set; }
    }
    public class Bar
    {
        public string Label { get; set; }
    }
}
Live demo : https://dotnetfiddle.net/SNqZX1
In this exemple I have used [CsvHelper](https://joshclose.github.io/CsvHelper/) for CSV serialisation, and [Json.NET](https://www.newtonsoft.com/json) for the Json serialisation. Note that Writing a CSV to a file is a more simlpe task that to a string like in this [example](https://joshclose.github.io/CsvHelper/examples/writing/write-class-objects/)
