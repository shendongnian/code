csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
public class HangfireTestDTO
{
    public int InputType { get; set; }
    public int EngineSubType { get; set; }
    public string Filename { get; set; }
    public string FileExtensionType { get; set; }
}
class Program
{
    static void Main()
    {
        string data =
          "[\"{\\\"InputType\\\":12,\\\"EngineSubType\\\":2,\\\"Filename\\\":\\\"targetFile.csv\\\",\\\"FileExtensionType\\\":\\\".csv\\\",\\\"IsLoadFile\\\":true,\\\"LoadContextId\\\":4120,\\\"ReportingDate\\\":\\\"2019-05-31T00:00:00\\\",\\\"IsSuccess\\\":false}\"]";
        // First deserialize the single string to a list of strings
        List<string> jsonStrings = JsonConvert.DeserializeObject<List<string>>(data);
        // Then deserialize each of the strings to a DTO.
        List<HangfireTestDTO> dtos = jsonStrings
            .Select(json => JsonConvert.DeserializeObject<HangfireTestDTO>(json))
            .ToList();
        Console.WriteLine(dtos.Count);
        Console.WriteLine(dtos[0].Filename);
    }
}
