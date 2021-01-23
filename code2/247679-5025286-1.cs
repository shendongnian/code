    using HtmlAgilityPack;
...
    HtmlDocument doc = new HtmlDocument();
    doc.Load(@"C:\file.html");
    bool flag = false;
    var sb = new StringBuilder();
    foreach (var n in doc.DocumentNode.SelectNodes("//p"))
    {
        switch (n.InnerText)
        {
            case "[section=quote]":
                flag = true;
                continue;
            case "[/section]":
                flag = false;
                break;
        }
        if (flag)
        {
            sb.AppendLine(n.OuterHtml);
        }
    }
    Console.Write(sb);
    Console.ReadLine();
