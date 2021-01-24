c#
//Install-Package Newtonsoft.Json
using Newtonsoft.Json;
using System.Data;
namespace Split_string_and_assign_as_table
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[
    {
        ""Type"": ""#Microsoft.Azure"",
        ""Email"": ""abc@tmail.com"",
        ""DisplayName"": ""abc"",
        ""Dpt"": ""home""
    },
    {
        ""Type"": ""#Microsoft.Azure"",
        ""Email"": ""xyz@tmail.com"",
        ""DisplayName"": ""xyz"",
        ""Dpt"": ""home""
    }
]";
            var dataTable = JsonConvert.DeserializeObject<DataTable>(json);
        }
    }
}
