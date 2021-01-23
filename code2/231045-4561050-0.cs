    using Excel = Microsoft.Office.Interop.Excel; 
    
        object oMissing = System.Reflection.Missing.Value;
        Excel.ApplicationClass xl=new Excel.ApplicationClass();
            Excel.Workbook xlBook;
            Excel.Worksheet xlSheet;
            string laPath = Server.MapPath(@"\excel\xl_table.xls");
            xlBook = (Workbook)xl.Workbooks.Open(laPath,oMissing,
              oMissing,oMissing,oMissing ,oMissing,oMissing,oMissing
             ,oMissing,oMissing,oMissing,oMissing,oMissi ng,oMissing,oMissing);
            xlSheet = (Worksheet)xlBook.Worksheets.get_Item(1);
            xlSheet.Name = "CIAO";
            xlBook.Save();
            xl.Application.Workbooks.Close();
