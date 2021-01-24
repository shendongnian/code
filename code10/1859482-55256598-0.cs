            string filename = @"C:\xxxxx_in.docx";
            Microsoft.Office.Interop.Word.Application oWord1 = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Application oWord2 = new Microsoft.Office.Interop.Word.Application();
            int pages = 3;
            try
            {
                Microsoft.Office.Interop.Word.Document oDoc2 = oWord2.Documents.Add();
                for (int i = 0; i < pages; i++)
                {
                    Microsoft.Office.Interop.Word.Document oDoc1 = oWord1.Documents.Open(filename);
                    object matchCase = false;
                    object matchWholeWord = true;
                    object matchWildCards = false;
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
                    object replace = 2;
                    object wrap = 1;
                    object findText = "#";
                    object replaceWithText = i.ToString();
                    oDoc1.Content.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                        ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
                    Microsoft.Office.Interop.Word.Range oRange = oDoc1.Content;
                    oRange.Copy();
                    
                    oDoc2.Range(oDoc2.Content.End - 1, oDoc2.Content.End - 1).Paste();
                    if (i + 1 < pages)
                    {
                        oDoc2.Range(oDoc2.Content.End - 1, oDoc2.Content.End - 1).InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);
                    }
                    oDoc1.Close(false);
                }
                object outputFileName = @"C:\xxxxx_out.docx";
                oDoc2.SaveAs(ref outputFileName);
                oDoc2.Close(false);
            }
            catch (Exception ex)
            {
                // Do something.
            }
            finally
            {
                oWord1.Quit(false);
                oWord2.Quit(false);
            }
