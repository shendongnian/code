c#
string input = "Length 2 01 02";
int length = 2;
string msg = "01 02";
// Let's declare a regex to match our input:
Match m = Regex.Match(input, @"^Length \d+\s+\d+\s+\d+$");
if (m.Success)
    Console.WriteLine("Match!"); // Works
// Now let's declare groups to access
m = Regex.Match(input, @"^Length (\d+)\s+(\d+)\s+(\d+)$");
if (m.Success)
{
    Console.WriteLine("Match!"); // Works
    Console.WriteLine(m.Groups[0].ToString()); // Group 0 is complete matched string
    Console.WriteLine(m.Groups[1].ToString()); // first braces..
    Console.WriteLine(m.Groups[2].ToString()); // second.. etc..
    Console.WriteLine(m.Groups[3].ToString());
}
// Now let's name our groups. (xxx) = group, (?<name>xxx) = group with name "name"
m = Regex.Match(input, @"^Length (?<FirstGroup>\d+)\s+(?<SecondGroup>\d+)\s+(?<ThirdGroup>\d+)$");
if (m.Success)
{
    Console.WriteLine("Match!"); // Works
    Console.WriteLine(m.Groups["FirstGroup"].ToString()); // Now we access the groups by their names
    Console.WriteLine(m.Groups["SecondGroup"].ToString());
    Console.WriteLine(m.Groups["ThirdGroup"].ToString());
}
