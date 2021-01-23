    ConnectionsPart part = wookbookPart.AddNewPart<ConnectionsPart>("rId5");
    Connections connections1 = new Connections();
    Connection connection1 = new Connection(){ Id = (UInt32Value)1U, Name = "note", Type = (UInt32Value)4U, RefreshedVersion = 0, Background = true };
    WebQueryProperties webQueryProperties1 = new WebQueryProperties(){ XmlSource = true, SourceData = true, Url = "C:\\Users\\Thomas\\Desktop\\note.xml", HtmlTables = true, HtmlFormat = HtmlFormattingValues.All };
    connection1.Append(webQueryProperties1);
    connections1.Append(connection1);
    part.Connections = connections1;
