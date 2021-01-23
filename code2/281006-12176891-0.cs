            Word.Application oWord = new Word.Application();
            Word.Document oWordDoc = new Word.Document();
            Object oMissing = System.Reflection.Missing.Value;
            object oTemplatePath = @"C:\\Documents and Settings\\Student\\Desktop\\ExportFiles\\" + "The_One.docx"; 
            oWordDoc = oWord.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            oWordDoc.ActiveWindow.Selection.WholeStory();
            oWordDoc.ActiveWindow.Selection.Copy();
            oWord.ActiveDocument.Select();
            // The Visible flag is what you've missed. You actually succeeded in making
            // the copy, but because
            // Your Word app remained hidden and the newly created document unsaved, you could not 
            // See the results.
            oWord.Visible = true;
            oWordDoc.ActiveWindow.Selection.PasteAndFormat(Word.WdRecoveryType.wdPasteDefault);
