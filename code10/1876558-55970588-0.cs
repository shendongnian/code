using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
namespace JsonExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var sb = new StringBuilder();
            var line = string.Empty;
            while (!string.IsNullOrWhiteSpace((line = Console.ReadLine())))
            {
                sb.AppendLine(line);
            }
            var json = sb.ToString().Trim();
            var obj = JsonConvert.DeserializeObject<Base>(json);
            var resultObj = new
            {
                Type = obj.Type,
                Parameters = obj.Parameters
                .Select(p => new { A = p.A, B = p.B, C = p.C })
            };
            Console.WriteLine("Serializing Object");
            Console.WriteLine(JsonConvert.SerializeObject(resultObj, Formatting.Indented));
        }
    }
    public class Base
    {
        public string Type { get; set; }
        public ParameterBase[] Parameters { get; set; }
    }
    public class ParameterBase
    {
        public ParameterInfo A { get; set; }
        public ParameterInfo B { get; set; }
        public ParameterInfo C { get; set; }
        public ParameterInfo D { get; set; }
        public ParameterInfo E { get; set; }
        public DropdownInfo F { get; set; }
    }
    public class ParameterInfo
    {
        public string Type { get; set; }
        public string DefaultValue { get; set; }
    }
    public class DropdownInfo
    {
        public string Type { get; set; }
        public string DefaultValue { get; set; }
        public string[] DropDownItems { get; set; }
    }
}
