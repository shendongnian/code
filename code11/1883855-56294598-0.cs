        public string ExtractText()
        {
            var app = new Microsoft.Office.Interop.Word.Application();
            Document document = app.Documents.Open(@"C:\Test\90.docx");
      
         
        //    app.ActiveDocument.Protect.p
            String read = string.Empty;
            List<string> data = new List<string>();
            for (int i = 0; i < document.Paragraphs.Count; i++)
            {
                string temp = document.Paragraphs[i + 1].Range.Text.Trim();
                if (temp != string.Empty)
                    data.Add(temp);
            }
            data.Add("Next LINE");
            data.Add("Next LINE");
            data.Add("Second method opens the existing Microsoft Office Word document specified by a fully qualified path and file name. This method returns a Document that represents the opened document");
            data.Add("Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney C");
            object missing = System.Reflection.Missing.Value;
       app.ActiveDocument.Content.Editors.Add(Microsoft.Office.Interop.Word.WdEditorType.wdEditorEveryone);
            foreach (var item in data)
            {
             var para = document.Content.Paragraphs.Add(ref missing);
              para.Range.Text = item.Trim();
              para.Range.InsertParagraphAfter();
 
         app.Visible = true;
            object noReset = true;
            object password = System.String.Empty;
            object useIRM = false;
            object enforceStyleLock = true;
            object PasswordEncryptionFileProperties = false;
            app.ActiveDocument.EnforceStyle = true;
            document.Protect(Microsoft.Office.Interop.Word.WdProtectionType.wdAllowOnlyReading, ref noReset, "000", ref useIRM, ref enforceStyleLock);
            document.Paragraphs[1].Range.Editors.Add(Microsoft.Office.Interop.Word.WdEditorType.wdEditorEditors);
            document.Paragraphs[2 + 1].Range.Editors.Add(Microsoft.Office.Interop.Word.WdEditorType.wdEditorEveryone);
            document.Paragraphs[1 + 1].Range.Editors.Add(Microsoft.Office.Interop.Word.WdEditorType.wdEditorEditors);
            
           
            document.Save();
            document.Close();}
