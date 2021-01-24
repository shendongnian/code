    string input = "AAAAAAAE&#x2B;uc=";
    string decoded = HttpUtility.HtmlDecode(input);
    byte[] bytes = Convert.FromBase64String(decoded);
    string output = string.Join("", bytes.Select(b => b.ToString("x2")));
    Console.WriteLine(output);
