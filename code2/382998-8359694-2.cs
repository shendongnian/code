    var csv = IO.File.ReadAllText(csvPath);
    var ws = pck.Workbook.Worksheets.Add("Test");
    var format As New ExcelTextFormat();
    format.Delimiter = '|';
    // if columns 4 shall not be interpreted like a DateTime 
    format.DataTypes = new eDataTypes[]{null, null, null, eDataTypes.String};
    var range = ws.Cells("A1").LoadFromText(csv, format);
