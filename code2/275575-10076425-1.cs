         private void InsertMultiFormatParagraph(string psText, int piSize, int piSpaceAfter = 10) {
            Word.Paragraph para = mdocWord.Content.Paragraphs.Add(ref mobjMissing);
            para.Range.Text = psText;
            // Explicitly set this to "not bold"
            para.Range.Font.Bold = 0;
            para.Range.Font.Size = piSize;
            para.Format.SpaceAfter = piSpaceAfter;
            object objStart = para.Range.Start;
            object objEnd = para.Range.Start + psText.IndexOf(":");
            Word.Range rngBold = mdocWord.Range(ref objStart, ref objEnd);
            rngBold.Bold = 1;
            para.Range.InsertParagraphAfter();
        }
    
