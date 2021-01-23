    string[] inputs =
    {
        "href=\"/image-ZOOM.aspx?UPPERcasE=someThing\"", // match
        "href=\"/image-coorect.aspx\"",  // no match, lowercase
        "href=\"javascript:function();\"", // no match, javascript
        "href=\"/images/PDFs/<%=Product.ShortSku %>.pDf\"", // bypass <% %> content
    };
    
    string pattern = @"href=""(?!javascript:)(?=[^""]*[A-Z])(?<Start>[^""<]+)(?<Special><%[^""]+%>)?(?<End>[^""]*)""";
    
    foreach (var input in inputs)
    {
        Console.WriteLine("{0,6}: {1}", Regex.IsMatch(input, pattern), input);
        string result = Regex.Replace(input, pattern,
                            m => "href=\""
                                + m.Groups["Start"].Value.ToLower()
                                + m.Groups["Special"].Value
                                + m.Groups["End"].Value.ToLower()
                                + "\"");
        Console.WriteLine("Result: " + result);
        Console.WriteLine();
    }
