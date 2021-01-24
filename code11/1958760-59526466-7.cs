    private void SetHeadersForSections(Word.Document doc) {
      foreach (Word.Section section in doc.Sections) {
        Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
        headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
        headerRange.Text = "XYZ";
        headerRange.Font.Size = 18;
        headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
      }
    }
