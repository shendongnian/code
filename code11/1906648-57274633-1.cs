    using System.Linq;
    ...
    public static string Dump(string value) => value == null
      ? "null" //TODO: put desired representation of the null string here
      : "\"" + string.Concat(value.Select(c => $"\\u{((int)c):x4}")) + "\"";
    ...
    public const string Numeric0 = "\u0030";
    ...
    string str = Dump(Numeric0);
    Console.WriteLine(str);
