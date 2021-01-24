    using Word = Microsoft.Office.Interop.Word;
    private Word.Range FindAndReplace(Word.Range rngToSearch, object findText, object replaceWithText)
            {
                bool found = false;
                //options
                object matchCase = false;
                object matchWholeWord = true;
                object matchWildCards = true;
                object matchSoundsLike = false;
                object matchAllWordForms = false;
                object forward = true;
                object format = false;
                object matchKashida = false;                     
                object matchDiacritics = false;
                object matchAlefHamza = false;
                object matchControl = false;
                object read_only = false;
                object visible = true;
                object replace = false;
                object wrap = 1;
                //execute find and replace
                found = rngToSearch.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                    ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                    ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
              if (!found)
              {
                rngToSearch = null;
              }
              return rngToSearch;
            }
    
            private void Button3_Click(object sender, RibbonControlEventArgs e)
            {
                Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
                Word.Range rng = doc.Content;
                string searchTerm = @"<[0-9]-[0-9]{1;}-[0-9]{1;}/[0-9]{1;}>";
                string hyperlink = "";  //put your hyperlink stuff here
                foreach (Word.Paragraph paragraph in doc.Paragraphs)
                {
                    Word.Range rngFound = FindAndReplace(rng, searchTerm, ""); //searching and wrapping.
    
                    if (rngFound != null)
                    {
                    Word.Hyperlink hp = (Word.Hyperlink)
                        rngFound.Hyperlinks.Add(rngFound, hyperlink + rngFound.Text);
                    }
                }
     }
