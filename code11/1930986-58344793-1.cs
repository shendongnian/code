    Word.Selection FindAndReplace(Word.Selection rngToSearch, object findText, object replaceWithText) //funcija poiska 4erez range
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
                object wrap = Word.WdFindWrap.wdFindStop;;
    
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
                int WordsCount = 0;
              
                int counter = 0;
                Word.Application app = Globals.ThisAddIn.Application;
                Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
                Word.Range rng = doc.Content;
                string searchTerm = @"<[0-9]-[0-9]{1;}-[0-9]{1;}/[0-9]{1;}>";
                string hyperlink = "google.com";  //
                string s = rng.Text; // Pushing doc text to the string
                Regex regex = new Regex(@"\d*-\d*-\d*/\d*"); 
                WordsCount = regex.Matches(s).Count; // Using regex getting count of searchable words 
                
    
                
                
        
                while (WordsCount >= counter ) // knowing count of words we know how much iterations we need to do.  
                    foreach (Word.Section paragraph in doc.Sections)
                {
                        Word.Selection rngFound = FindAndReplace(app.Selection, searchTerm, ""); //searching and wrapping.
    
                        if (rngFound != null)
                    {
                  
                            rngFound.Range.Hyperlinks.Add(rngFound.Range, hyperlink + rngFound.Text);
                           
                    }counter++; // counting iterations
                        
    
                    }
            }
