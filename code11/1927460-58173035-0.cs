using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
namespace extractingJSONSyslogQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
			var input = File.ReadAllText("test.txt");
            var lines = input.Split("\n");
            // Remove blank lines
            lines = lines.Where(l => !string.IsNullOrEmpty(l)).ToArray();
            foreach(var line in lines) {
                // Get rid of log prefix
                var data = line.Substring(line.IndexOf("{"));
                var json = JObject.Parse(data);
                Console.WriteLine(json);
            }
        }
    }
}
Here is the input file that I used. Notice that I added double quotes around the string "detail" to make it valid json:
<14>1 09 30 2019 15:34:37 UTC logsource {"somejson": "thejson", "details": {"detail1": "detail", "detail2": "detail"}}
<14>1 09 30 2019 15:34:37 UTC logsource {"somejson": "thejson", "details": {"detail1": "detail", "detail2": "detail"}}
<14>1 09 30 2019 15:34:37 UTC logsource {"somejson": "thejson", "details": {"detail1": "detail", "detail2": "detail"}
Finally, here is the output from my program:
{
  "somejson": "thejson",
  "details": {
    "detail1": "detail",
    "detail2": "detail"
  }
}
{
  "somejson": "thejson",
  "details": {
    "detail1": "detail",
    "detail2": "detail"
  }
}
{
  "somejson": "thejson",
  "details": {
    "detail1": "detail",
    "detail2": "detail"
  }
}
I am happy to answer any questions about the code in more detail if you leave a comment.
