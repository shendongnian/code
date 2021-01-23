    private void InsertMultiFormatParagraph(string text, int size, int spaceAfter = 10) {
        var para = docWord.Content.Paragraphs.Add(ref objMissing);
        para.Range.Text        = text;
        // Explicitly set this to "not bold"
        para.Range.Font.Bold   = 0;
        para.Range.Font.Size   = size;
        para.Format.SpaceAfter = spaceAfter;
        var start = para.Range.Start;
        var end   = para.Range.Start + text.IndexOf(":");
        var rngBold = docWord.Range(ref objStart, ref objEnd);
        rngBold.Bold = 1;
        para.Range.InsertParagraphAfter();
    }
    
