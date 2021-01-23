        string s = "<span style=\"color: #0000FF;\"><</span>";
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(s);
        doc.Save(Console.Out);
        Console.WriteLine();
        Console.WriteLine();
        foreach (HtmlParseError err in doc.ParseErrors)
        {
            Console.WriteLine("Error");
            Console.WriteLine(" code=" + err.Code);
            Console.WriteLine(" reason=" + err.Reason);
            Console.WriteLine(" text=" + err.SourceText);
            Console.WriteLine(" line=" + err.Line);
            Console.WriteLine(" pos=" + err.StreamPosition);
            Console.WriteLine(" col=" + err.LinePosition);
        }
