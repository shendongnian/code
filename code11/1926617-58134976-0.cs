     private string GetWordFileText(string filepath)
            {
                Microsoft.Office.Interop.Word.ApplicationClass WordApp = null;
                Microsoft.Office.Interop.Word.Document doc = null;
                try
                {
                    WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
                    doc = WordApp.Documents.Open(filepath, Visible: false);
                    string toReturn = doc.Content.Text;
                    return toReturn;
                }
                catch (Exception e)
                { throw e; }
                finally
                {
                    doc.Close();
                    WordApp.Quit();
                }
            }
