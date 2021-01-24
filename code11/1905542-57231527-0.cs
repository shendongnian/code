    private void btnInsertPageNr_Click(object sender, EventArgs e)
    {
        getWordInstance();
        Word.Document doc = null;
        if (wdApp.Documents.Count > 0)
        {
            doc = wdApp.ActiveDocument;
            Word.Range rngHeader = doc.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
            if (rngHeader.Tables.Count > 0)
            {
                Word.Table tbl = rngHeader.Tables[1];
                Word.Range rngPageNr = tbl.Range.Cells[tbl.Range.Cells.Count].Range;
                //Collapse the range so that it's within the cell and 
                //doesn't include the end-of-cell markers
                object oCollapseStart = Word.WdCollapseDirection.wdCollapseStart;
                rngPageNr.Collapse(ref oCollapseStart);
                rngPageNr = InsertNewText(rngPageNr, "Page ");
                rngPageNr = InsertAField(rngPageNr, "Page");
                rngPageNr = InsertNewText(rngPageNr, " of ");
                rngPageNr = InsertAField(rngPageNr, "NumPages");
            }
        }
    }
    private Word.Range InsertNewText(Word.Range rng, string newText)
    {
        object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
        rng.Text = newText;
        rng.Collapse(ref oCollapseEnd);
        return rng;
    }
    private Word.Range InsertAField(Word.Range rng,
                          string fieldText)
    {
        object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
        object unitCharacter = Word.WdUnits.wdCharacter;
        object oOne = 1;
        Word.Field fld = rng.Document.Fields.Add(rng, missing, fieldText, false);
        Word.Range rngField = fld.Result;
        rngField.Collapse(ref oCollapseEnd);
        rngField.MoveStart(ref unitCharacter, ref oOne);
        return rngField;
    }
