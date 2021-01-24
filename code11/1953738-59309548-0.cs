    private void runFiles(string _path) 
        {
            string path = _path;
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            DirectoryInfo d = new DirectoryInfo(path);
            FileInfo [] listOfFiles = d.GetFiles("*.xlsx*").ToArray();
            xlApp.DisplayAlerts = false;
            foreach (FileInfo file in listOfFiles)
            {
              
                    var xlWorkBook = xlApp.Workbooks.Open(file.FullName);
                    Worksheet xlWorkSheet = xlWorkBook.Sheets["SheetName"];
                    //Code Here;
                    
                    xlWorkBook.Save();
                    xlWorkBook.Close();
            }
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
