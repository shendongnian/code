    string str = "|1 Test 1|This is my first line.|2 Test 2|This is my second line.";
    var pattern = @"(\|(?:.*?)\|)";
    foreach (var m in System.Text.RegularExpressions.Regex.Split(str, pattern))
    {
        Console.WriteLine(m);
    }
