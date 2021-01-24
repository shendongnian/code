           Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
            Word.Range rng = doc.Content;
            string searchTerm = @"<[0-9]-[0-9]{1;}-[0-9]{1;}/[0-9]{1;}>";
            string hyperlink = "";  //put your hyperlink stuff here
            foreach (Word.Paragraph paragraph in doc.Paragraphs)
            {
                rng = paragraph.Range;
                System.Diagnostics.Debug.Print(rng.Text);  
                Word.Range rngFound = FindAndReplace(rng, searchTerm, ""); //searching and wrapping.
                if (rngFound != null)
                {
                //Word.Hyperlink hp = (Word.Hyperlink)
                System.Diagnostics.Debug.Print(rngFound.Text);
                }
            }
