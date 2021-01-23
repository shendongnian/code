    // using System.Text.RegularExpressions;
    // pattern = any number of arbitrary characters between #.
    var pattern = @"#(.*?)#";
    var matches = Regex.Matches(htmlString, pattern);
    foreach (Match m in matches) {
        Console.WriteLine(m.Groups[1]);
    }
