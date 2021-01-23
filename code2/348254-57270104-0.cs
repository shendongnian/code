    Microsoft.Office.Interop.Excel.Application oXL = new  Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel._Workbook oWB;
    Microsoft.Office.Interop.Excel._Worksheet oSheet;
    Microsoft.Office.Interop.Excel.Range oRng;
    //create exel
    oWB = oXL.Workbooks.Open(@"C:\Users\\Desktop\Test.xlsx");
    oXL.Visible = true;//Can make it false when don't want to see the excel file
    //give u name of workbook
     string ExcelWorkbookname = oWB.Name;
    // statement get the worksheet count  
     int worksheetcount = oWB.Worksheets.Count;
    string path = oWB.Path;
    
    oSheet = (_Worksheet)oWB.Sheets.get_Item(1);
    string str = oSheet.Name;
    //IMP: on Excel right click on drop down u can see the drop down name on left top most corner which u r providing below.
    // It can be anything like Drop Down 5,Drop Down 6,Drop Down 7 etc
      var dropdownValue= oSheet.Shapes.Item("Drop Down 5").ControlFormat; 
    dropdownValue.ListIndex = 2; //This allows you to change the drop down to 2nd element
