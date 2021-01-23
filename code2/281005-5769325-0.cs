            static void Main(string[] args)
        {
            Word.Application oWord = new Word.Application();
            oWord.Visible = true;  // shows Word application
            Word.Document oWordDoc = new Word.Document();
            Object oMissing = System.Reflection.Missing.Value;
            oWordDoc = oWord.Documents.Add(ref oMissing);
            Word.Range r = oWordDoc.Range();
            r.InsertAfter("Some text added through automation!");
            r.InsertParagraphAfter();
            r.InsertParagraphAfter();
            r.Collapse(Word.WdCollapseDirection.wdCollapseEnd);  // Moves range at the end of the text
            string path = @"C:\Temp\Letter.doc";
             // Insert whole Word document at the given range, omitting page layout
             // of the inserted document (if it doesn't contain section breakts)
            r.InsertFile(path, ref  oMissing, ref oMissing, ref oMissing, ref oMissing);
        }
