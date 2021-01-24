    using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Worksheet1");
                excel.Workbook.Worksheets.Add("Worksheet2");
                excel.Workbook.Worksheets.Add("Worksheet3");
    
                var worksheet = excel.Workbook.Worksheets["Worksheet1"]; 
    
                string FileRootPath = "http://www.google.com";
                 
                string url  = String.Format("HYPERLINK(\"{0}\",\"" + "{1}" + "\")", FileRootPath, "Test display");
    
                worksheet.Cells[1, 1].Formula = url; // "HYPERLINK(\"" + FileRootPath + "\",\"" + "TEST display" + "\")";
    
                FileInfo excelFile = new FileInfo(@"C:\ProjectWork\test.xlsx");
                excel.SaveAs(excelFile);
            } 
