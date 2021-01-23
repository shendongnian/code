    string pattern = @"<body[^>]*>";
    string test = @"<body bgcolor=""White"" style=""font-family:sans-serif;font-size:10pt;"">";
    string result = Regex.Replace(test,pattern,"<body>",RegexOptions.IgnoreCase);
    Console.WriteLine("{0}",result);
    string pattern2 = @"(?<=<body[^>]*)\s*style=""[^""]*""(?=[^>]*>)";
    result = Regex.Replace(test, pattern2, "", RegexOptions.IgnoreCase);
    Console.WriteLine("{0}",result);
