csharp
static IEnumerable<string> SplitCamelCase(string input)
{
   return Regex.Split(input, @"([A-Z]?[a-z]+)").Where(str => !string.IsNullOrEmpty(str));
}
It works by splitting the string using "an uppercase letter followed by one or more lowercase letters" (or just one or more lowercase letters) as a delimiter.  `string.Split` will include the delimiters in the result array if they are captured in parentheses (and they are, in my example).  And this leaves only the spans of capital letters (all but the last) occurring between delimiters, which `string.Split` will include in the array naturally.  It does produce superfluous empty strings in some cases, but they can be filtered out; I did so with a `.Where` clause.
It's not bad.  I only wish there were a nicer way to eliminate the empty strings more easily.
By the way, I elected to return `IEnumerable<string>` because I feel like that format is more reusable. But you can always `.ToArray()` the result if you prefer an array, or the result can be joined with spaces using `string.Join(" ", result)` to form your corrected string.
Here's a complete demonstration:
csharp
class Program
{
    static IEnumerable<string> SplitCamelCase(string input)
    {
        return Regex.Split(input, @"([A-Z]?[a-z]+)").Where(str => !string.IsNullOrEmpty(str));
    }
    static void Main(string[] args)
    {
        string[] examples = new string[] {
            "FYYear",
            "CostCenter",
            "cosTCenter",
            "CostcenteR",
            "COSTCENTER"
        };
        foreach (string str in examples) {
            Console.WriteLine("{0, 10} -> {1}", str, String.Join(" ", SplitCamelCase(str)));
        }
    }
}
Output:
    FYYear -> FY Year
CostCenter -> Cost Center
cosTCenter -> cos T Center
CostcenteR -> Costcente R
COSTCENTER -> COSTCENTER
