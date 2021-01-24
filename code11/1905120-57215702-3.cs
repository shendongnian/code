using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
public class Program
{
    public static void Main()
    {
        string inputCSV = @"""Type"":""#Microsoft.Azure"",""Email"":""abc@tmail.com"",""DisplayName"":""abc"",""Dpt"":""home""
""Type"":""#Microsoft.Azure"",""Email"":""xyz@tmail.com"",""DisplayName"":""xyz"",""Dpt"":""home""";
        
        // ReadAllLines mock
        string[] lines = inputCSV.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        { // The Json Way
            var bringJsonBack = "[\n{" + string.Join("},\n{", lines) + "}\n]";
            var results = JsonConvert.DeserializeObject<List<CsvItem>>(bringJsonBack);
            results.Dump();
        }
        { // Your working way
            var results = new List<CsvItem>();
            foreach (var line in lines)
            {
                var temp = new CsvItem();
                string[] strS1 = line.Split(',');
                foreach (string S1 in strS1)
                {
                    string[] strS2 = S1.Split(':');
                    
                    // You have a part Before the : and one after we just string check to know what property we re on.
                    if (strS2[0].Trim('"') == "Email")
                    {
                        temp.Email = strS2[1].Trim('"');
                    }
                    if (strS2[0].Trim('"') == "DisplayName")
                    {
                        temp.DisplayName = strS2[1].Trim('"');
                    }
                    if (strS2[0].Trim('"') == "Dpt")
                    {
                        temp.Dpt = strS2[1].Trim('"');
                    }
                }
                results.Add(temp);
            }
            results.Dump();
        }
        { // LinQ Version of your algo.
            var results = lines
                                .Select(x => x.Split(','))
                                .Select(x =>
                                    new CsvItem
                                    {
                                        Email = x[1].Split(':')[1].Trim('"'),
                                        DisplayName = x[2].Split(':')[1].Trim('"'),
                                        Dpt = x[3].Split(':')[1].Trim('"')                                        
                                    })
                                .ToList();
            results.Dump();
        }
    }
    public class CsvItem
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Dpt { get; set; }
    }
}
