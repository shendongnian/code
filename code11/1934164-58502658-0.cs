    using (WordprocessingDocument theDoc = WordprocessingDocument.Open(docName, true))
    {
        MainDocumentPart mainPart = theDoc.MainDocumentPart;
        foreach (SdtElement sdt in mainPart.Document.Descendants<SdtElement>())
        {
            SdtAlias alias = sdt.Descendants<SdtAlias>().FirstOrDefault();
            if (alias != null && alias.Val.Value == "Body")
            {
                var run = sdt.Descendants<Run>().FirstOrDefault();
                run.RemoveAllChildren<Text>();
    
                var text = "Welcome to Yazd With its winding lanes, forest of badgirs,\r\n mud-brick houses and delightful places to stay, Yazd is a 'don't miss' destination. On a flat plain ringed by mountains, \r\nthe city is wedged between the northern Dasht-e Kavir and southern Dasht-e Lut and is every inch a city of the desert.";
                var lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
    
                foreach (var line in lines)
                {
                    run.AppendChild(new Text(line));
                    run.AppendChild(new Break());
                }
    
                run.Elements<Break>().Last().Remove();
            }
        }
    }
