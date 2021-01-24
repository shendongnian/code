        TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
        string[] lines = textRange.Text.Trim().Split('\r');
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Contains(findword) && replaceword == string.Empty)
                {
                    lines[i] = "";
                }
            }
            //textRange.Text = string.Join("", lines);         
            string rtf = string.Empty;
            MemoryStream objmemoryStream = new MemoryStream();
            textRange.Save(objmemoryStream, DataFormats.Rtf);
            rtf = System.Text.ASCIIEncoding.Default.GetString(objmemoryStream.ToArray());           
            rtf = rtf.Replace(findword, replaceword);  
            MemoryStream objmemoryStream1 = new MemoryStream(System.Text.ASCIIEncoding.Default.GetBytes(rtf));
            rtfTestResult.SelectAll();
            rtfTestResult.Selection.Load(objmemoryStream1, DataFormats.Rtf);
 
