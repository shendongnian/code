    public static void CreateDoc(string ebillpath)
    {
        DocumentModel doc = new DocumentModel();
    
        CharacterFormat charFormat = doc.DefaultCharacterFormat;
        charFormat.Size = 10;
        charFormat.FontName = "Courier New";
    
        ParagraphFormat parFormat = doc.DefaultParagraphFormat;
        parFormat.SpaceAfter = 0;
        parFormat.LineSpacing = 1;
    
        // It seems you want to skip first line with 'clearedtop'.
        // So maybe you could just use this instead.
        string text = string.Concat(File.ReadLines(ebillpath).Skip(1));
        doc.Content.LoadText(text);
    
        Section section = doc.Sections[0];
        PageMargins margins = section.PageSetup.PageMargins;
        margins.Bottom = 36;
        margins.Top = 36;
        margins.Right = 36;
        margins.Left = 36;
    
        doc.Save(@"d:\temp\test.pdf");
    }
