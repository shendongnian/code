    static void ParseHtml()
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(htmlCode);
        var cells = doc.DocumentNode
                        .SelectNodes(@"//table[1]/tr/td[@class='statBox']")
                        .Select(node => node.InnerText.Trim())
                        .Take(18)
                        .ToList();
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",
            OmitXmlDeclaration = false,
            Encoding = Encoding.UTF8,
        };
        using (var writer = XmlWriter.Create(filepath, settings))
        {
            writer.WriteStartElement("Stats");
            writer.WriteAttributeString("Date", DateTime.Now.ToShortDateString());
            writer.WriteStartElement("Player");
            writer.WriteAttributeString("Rank", cells.First());
            var nodes = cells.Skip(1)
                                .Zip(new[] { "Name", "Team", "Pos", "GP", "G", "A", "PlusMinus", "PIM", "PP", "SH", "GW", "OT", "Shots", "ShotPctg", "TOIPerGame", "ShiftsPerGame", "FOWinPctg" },
                                    (v, t) => Tuple.Create(t, v))
                                .Where(t => !String.IsNullOrEmpty(t.Item2));
            foreach (var t in nodes)
                writer.WriteElementString(t.Item1, t.Item2);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
