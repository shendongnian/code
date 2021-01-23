    void MoveToParagraph(Microsoft.Office.Interop.Word.Document d, int number)
    {
        Microsoft.Office.Interop.Word.Range r = d.Paragraphs[number].Range;
        object dir = Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseStart;
        
        r.Collapse(ref dir);
        r.Select();
    }
