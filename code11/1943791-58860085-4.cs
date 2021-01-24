csharp
using System;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
class Program
{    
    static void Main(string[] args)
    {
        var writer = new JsonTextWriter(Console.Out);
        var list = new List<double>
        {
            -9.811880E-002,
            2.236657E-002,
            -4.020144E-001
        };
        WriteList(writer, list);
    }
    
    static void WriteList(JsonWriter writer, List<double> list)
    {
        writer.WriteStartArray();
        foreach (var element in list)
        {
            writer.WriteRawValue(element.ToString("E", CultureInfo.InvariantCulture));
        }
        writer.WriteEndArray();
    }
}
Output:
text
[-9.811880E-002,2.236657E-002,-4.020144E-001]
