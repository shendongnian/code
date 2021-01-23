    string input = "test, and test but not testing.  But yes to test";
    string pattern = @"\btest\b";
    string replace = "text";
    string result = Regex.Replace(input, pattern, replace);
    Console.WriteLine(result);
