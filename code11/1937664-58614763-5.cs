using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
(...)
public static void Main(string[] args)
{
    string input = "{1, 'Western Australia', 1, 3}, {2, 'othello', 0, 2}";
    var pattern = "{(.*?)}";
    var matches = Regex.Matches(input, pattern);
    var separated = matches
                .Select(m => m.Groups[1].ToString())
                .ToList();
    var os = new Program().CreateInstances(separated).ToList();
}
IEnumerable<Data> CreateInstances(IEnumerable<string> separated)
    => separated.Select(o =>
        {
            var parts = o.Split(',').Select(s => s.Trim()).ToList();
            return new Data(
                int.Parse(parts[0]),
                parts[1].Trim('\''),
                int.Parse(parts[2]),
                int.Parse(parts[3]));
        });
----
# Test
## Code
// I made fields public just to print the values
foreach(var o in os ) Console.WriteLine($"id={o.id}, desc={o.desc}, state={o.state}, res={o.res}");
## Output
// .NETCoreApp,Version=v3.0
id=1, desc=Western Australia, state=1, res=3
id=2, desc=othello, state=0, res=2
