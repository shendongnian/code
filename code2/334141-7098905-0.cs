    // Open Template
    FileStream fs = new FileStream(Server.MapPath(@"\template\Template_EventBudget.xls"), FileMode.Open, FileAccess.Read);
     
    // Load the template into a NPOI workbook
    HSSFWorkbook templateWorkbook = new HSSFWorkbook(fs, true);
     
    // Load the sheet you are going to use as a template into NPOI
    HSSFSheet sheet = templateWorkbook.GetSheet("Event Budget");
     
    // Insert data into template
    sheet.GetRow(1).GetCell(1).SetCellValue(EventName.Value);  // Inserting a string value into Excel
    sheet.GetRow(1).GetCell(5).SetCellValue(DateTime.Parse(EventDate.Value));  // Inserting a date value into Excel
     
    sheet.GetRow(5).GetCell(2).SetCellValue(Double.Parse(Roomandhallfees.Value));  
