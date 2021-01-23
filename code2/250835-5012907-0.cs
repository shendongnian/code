    public class FormulaImageConverter: IDisposable
    {
        private Guid _guid;
        
        private Application _wordApp;
        private Document _doc;
        private Range _range;
        
        private string _saveName;
        private string _extractPath;
        
        public FormulaImageConverter(Application wordApp)
        {
            
            _wordApp = wordApp;
            _guid = Guid.NewGuid();
            string guidToString = _guid.ToString("N");
            string saveNameBase = System.IO.Path.Combine(System.IO.Path.GetTempPath(), guidToString);
            _saveName = saveNameBase + ".html";
            _extractPath = saveNameBase + @"_files\image002.gif";
    
            _wordApp.Visible = false;
            _doc = _wordApp.Documents.Add();
            _range = _doc.Range();
            _range.Text = "5";
            _doc.OMaths.Add(_range);
    
        }
    
        public byte[] ConvertFormulaToImage(string eq)
        {
            _range.Text = eq;
            _doc.OMaths.BuildUp();
            _doc.SaveAs(_saveName, WdSaveFormat.wdFormatHTML,Type.Missing,Type.Missing,false,Type.Missing,null,false);
    
            return System.IO.File.ReadAllBytes(_extractPath);
        }
    
        public void Dispose()
        {
            _range = null;
            _doc = null;
            _wordApp.Documents.Close(WdSaveOptions.wdDoNotSaveChanges);
            ((_Application)_wordApp).Quit(false);
            _wordApp = null;
            System.IO.File.Delete(_saveName);
            for (int i = 0; i < 2; i++)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
