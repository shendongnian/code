    Word.HeaderFooter hdr = doc.Sections[1].Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
    Word.Range hdrRange = hdr.Range;
    Word.Paragraphs paras = hdrRange.Paragraphs;
    for (int counter = 1; counter <= paras.Count; counter++)
    {
        Word.Paragraph para = paras[counter];
        if ((bool)para.Range.get_Information(Word.WdInformation.wdWithInTable))
        {
            //Get the table that belongs to the first paragraph in the table
            Word.Table tbl = para.Range.Tables[1];
            //Reset the counter so that it cycles to the paragraph after the table
            counter += tbl.Range.Paragraphs.Count - 1;
            Debug.Print("In table with " + (counter - 1).ToString() + " paragraphs");
            //Process the table
        }
        else
        {
            //Process the paragraph
            Debug.Print("Paragraph " + counter.ToString() + ": " + para.Range.Text);
        }
    }
