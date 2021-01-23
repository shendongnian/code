    using System.Text.RegularExpressions;
    var q = from ch in text.Distinct()
            select Regex.Match(text, ch.ToString());
    foreach (var item in q)
    {
        Console.WriteLine("{0}-{1}", item.Value, item.Index);
    }
