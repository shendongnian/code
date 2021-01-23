    using Microsoft.Office.Interop.Word;
    class Program
    {
        static void Main(string[] args)
        {
            DocumentClass document = new DocumentClass();
            object defaultTableBehavior = null, autoFitBehavior = null;
            Table tbl = document.Content.Tables.Add(document.Content, 2, 2, ref defaultTableBehavior,
                ref autoFitBehavior);
            tbl.Rows[2].Cells[2].Range.InsertAfter("This is a test.");
            tbl.Rows[2].Cells[2].Range.ParagraphFormat.SpaceAfter = 0f;
            tbl.Rows[2].Cells.Height = 50f;
            tbl.Range.Rows[2].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
        }
    }
