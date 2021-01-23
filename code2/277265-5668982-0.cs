     Microsoft.Office.Interop.Excel.Range Range = (Microsoft.Office.Interop.Excel.Range)Cell;
       int TextLength = Range.Text.ToString().Length;
       for (int CharCount = 1; CharCount <= TextLength; CharCount++)
       {
           Microsoft.Office.Interop.Excel.Characters charToTest = Range.get_Characters(CharCount, 1);
           bool IsBold = (bool)charToTest.Font.Bold;
           bool IsItalic = (bool)charToTest.Font.Italic;
           // other formatting tests here
    
       }
