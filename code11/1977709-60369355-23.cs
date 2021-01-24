    foreach (Paragraph p in document.Body.Descendants<Paragraph>())
    {
        foreach (Run r in p.Elements<Run>())
        {
            foreach (Break b in r.Descendants<Break>())
            {
                if (b.Type != null)
                {
                    if (b.Type.Value == BreakValues.Page)
                    {
                        b.Remove(); //Remove the page break
                        p.Descendants<ParagraphProperties>().FirstOrDefault().AppendChild(defaultProperties.CloneNode(true)); //Replace by a cloned section break
                    }
                }
            }
        }
    }
