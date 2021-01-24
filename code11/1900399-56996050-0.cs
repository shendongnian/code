        static void Main()
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range xlRange;
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;
            Word.Document wordDoc = wordApp.Documents.Open(@"c:\debug\word-excel.docm");
            
            // activate the object before you can interact with it
            wordDoc.InlineShapes[1].OLEFormat.Activate();
            
            xlWorkBook = wordDoc.InlineShapes[1].OLEFormat.Object;
            xlApp = xlWorkBook.Parent;
            xlWorkSheet = xlWorkBook.Worksheets[1];
            xlRange = xlWorkSheet.Range["A1:D10"];
        }
