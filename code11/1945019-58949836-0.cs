    private void button5_Click(object sender, RibbonControlEventArgs e)
            {
                int WordsCount2 = 0;
    
    
                string hyperlink = "https://Test";
                string searchTerm =
                    @"<([1-5])[-^~]([0-9]{2})[-^~]([0-9]{1;6})/([0-9]{1;4})>"; // testing with  2-19-1023/47 2-19-1023/49
    
    
                Word.Application app = Globals.ThisAddIn.Application;
                Word.Range rngSel = app.Selection.Range;
                string s = rngSel.Text;
                Word.Range rngSearch = rngSel.Duplicate;
                Regex regex2 = new Regex(@"\d*(-|\036)\d*(-|\036)\d*/\d*");
                if (regex2.Matches(s).Count != 0)
                {
                    WordsCount2 = regex2.Matches(s).Count;
    
           
    
                    while (WordsCount2 >= 1)
                    {
                        Word.Range rngFound = FindAndReplace(rngSel, searchTerm, "");
    
                        if (rngFound != null) { 
                            string foundNr = rngFound.Text;
                        string hyperlinkNr = foundNr.Replace((char)30, (char)45);
                        rngFound.Hyperlinks.Add(rngFound, hyperlink + hyperlinkNr);
                   
               
                        if (rngFound != null)
                        {
                            FindAndReplace2(rngSel, searchTerm, rngFound.Text.Replace((char)45, (char)30).Replace((char)32, (char)160));
                            //   File.AppendAllText(@"C:\install\CSharp\tulemus.txt", $"File name is: {rngFound.Text}" + Environment.NewLine)
                            
                        }
                        WordsCount2--;
                    }}
    
                }
            }
