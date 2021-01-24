        Word.Range rng = table.Cell[rowCounter, colCounter].Range;
        //convert the numbers to plain text, then undo the conversion
        rng.ListFormat.ConvertNumbersToText();
        string cellContent = rng.Text;
        objDoc.Undo(1);
        //remove end-of-cell characters
        cellContent = TrimCellText2(cellContent);
        //replace remaining paragraph marks with the Excel new line character
        cellContent.Replace((char)13, (char)10);
        worksheet.Cells[rowCounter, colCounter].Value = cellContent;
    //cut off ANSI 13 + ANSI 7 from the end of the string coming from a 
    //Word table cell
    private string TrimCellText2(s As String)
    {
        int len = s.Length;
        while (len > 0 && s.Substring(len - 1) == (char)13 || s.Substring(len - 1) == (char)7);
            s = s.Substring(0, Math.Min(len-1, len));   
        return s;
    }
