csharp
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
{'ItemName':'8','Id':1}
{'ItemName':'9','Id':2}
";
            var items = new List<Item>();
            var serializer = new JsonSerializer();
            using (var sr = new StringReader(json))
            {
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    jsonTextReader.SupportMultipleContent = true;
                    while (jsonTextReader.Read())
                    {
                        var data = serializer.Deserialize<Item>(jsonTextReader);
                        items.Add(data);
                    }
                }
            }
            foreach (Item item in items)
            {
                Console.WriteLine($"{item.Id}: {item.ItemName}");
            }
        }
    }
    public class Item
    {
        public string ItemName { get; set; }
        public int Id { get; set; }
    }
}
