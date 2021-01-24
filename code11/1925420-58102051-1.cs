c#
static void Main(string[] args)
{
    var s = "Room: 501, User: John, Model: XPR500   Serial: JK0192, Condition: Good";
    s = s.Replace(",", ""); // first, remove all the commas
    var delimiters = new string[] { "Room:", "User:", "Model:", "Serial:", "Condition:" };
    // use a function which doesn't assume the order or inclusion of all the delimiters
    model = getValue(s, delimiters, "Model:");
    serial = getValue(s, delimiters, "Serial:");
    Console.WriteLine($"Model = '{model}'");
    Console.WriteLine($"Serial = '{serial}'");
    Console.ReadLine();
}
private static string getValue(string s, string[] delimiters, string delimiter)
{
    // find the index of the beginning of the rest of the string after your sought title
    var index = s.IndexOf(delimiter) + delimiter.Length;
    // split the rest of the string by all the delimiters, take the first item
    return s.Substring(index).Split(delimiters, StringSplitOptions.RemoveEmptyEntries).First().Trim();
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=netframework-4.8#System_String_Split_System_String___System_Int32_System_StringSplitOptions_
