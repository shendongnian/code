    public void ParseHtml()
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(htmlCode);
        var cells = htmlDoc.DocumentNode
                                        // use the right XPath rather than looping manually
                           .SelectNodes(@"//tr/tr/td[@class='statBox']")
                           .Select(node => node.InnerText.Trim())
                           .ToList();
        var elementNames = new[] { "Name", "Team", "Pos", "GP", "G", "A", "PlusMinus", "PIM", "PP", "SH", "GW", "OT", "Shots", "ShotPctg", "TOIPerGame", "ShiftsPerGame", "FOWinPctg", "UnknownField" };
        var xmlDoc =
            new XElement("Stats", new XAttribute("Date", DateTime.Now.ToShortDateString()),
                new XElement("Player", new XAttribute("Rank", cells.First()),
                    // generate the elements based on the parsed cells
                    cells.Skip(1)
                         .Zip(elementNames, (Value, Name) => new XElement(Name, Value))
                         .Where(element => !String.IsNullOrEmpty(element.Value))
                )
            );
        // save to your file
        xmlDoc.Save(filepath);
    }
