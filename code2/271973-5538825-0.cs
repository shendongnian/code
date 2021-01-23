    Application excel = new Application();
    Workbook wb = excel.Workbooks.Open(path, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
    
        string lookFor="TabName1";
        
        foreach (Microsoft.Off.Interop.Excel.Worksheet w in wb.Worksheets)
         {
           if (w.Name == lookFor)
             //match exists rename
             w.Name = lookFor + "_renamed";
         }
        
          
