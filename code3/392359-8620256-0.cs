    string execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
    book = app.Workbooks.Open(execPath + @"\..\..\Book1.xls", 
           Missing.Value, Missing.Value, Missing.Value, 
           Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
           Missing.Value, Missing.Value, Missing.Value, Missing.Value, 
           Missing.Value, Missing.Value, Missing.Value);
    sheet = (Worksheet)book.Worksheets[1];
    range = sheet.get_Range("A1", Missing.Value);
