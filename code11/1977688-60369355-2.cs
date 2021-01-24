    List<string> newSectionHeaderIds = new List<string>();
    foreach (string groupHeaderText in lstReplace)
    {
        HeaderPart newGroupHeaderPart = mainDocPart.AddNewPart<HeaderPart>();
        string sId = mainDocumentPart.GetIdOfPart(newGroupHeaderPart);
        Header newHeader = (Header)defaultHeaderPart.Header.Clone();
    
        foreach (Paragraph p in newHeader.Descendants<Paragraph>())
        {
            foreach (Run r in p.Descendants<Run>())
            {
                foreach (Text t in r.Descendants<Text>())
                {
                    t.Text = t.Text.Replace("[GroupHeaderText1]", groupHeaderText);
                }
            }
        }
        newHeader.Save(newGroupHeaderPart);
        newSectionHeaderIds.Add(sId);
    }
