    string input = "<reply success=\"true\">More nodes go here</reply>";
    using (XmlReader xmlReader = XmlReader.Create(new StringReader(input)))
    {
        xmlReader.MoveToContent();
        string success = xmlReader.GetAttribute("success");
        Console.WriteLine(success);
    }
