    private void WriteText(string text)
        {
            var para = doc.Content.Paragraphs.Add();
            var start = para.Range.Start;
            var end = para.Range.Start + text.IndexOf(":");
            para.Range.Text = text;
            para.Range.Font.Bold = 0;
            para.Range.InsertParagraphAfter();
            
            if(text.Contains(":")){
                var rngBold = doc.Range(start, end);
                rngBold.Bold = 1;
            }
        }
