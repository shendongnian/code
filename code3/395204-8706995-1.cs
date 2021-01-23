    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application xlApp;
    Excel.Workbook xlWorkBook;
    Excel.Worksheet xlWorkSheet;
    Excel.Shape shp;
    
    shp = xlWorkSheet.Shapes.AddShape(Office.MsoAutoShapeType.msoShapeRectangle, 47, 280, 140, 90);
    shp.Fill.Visible = Office.MsoTriState.msoFalse;
    shp.TextFrame2.TextRange.Font.Bold = Office.MsoTriState.msoTrue;
    shp.TextFrame2.TextRange.Font.Name = "Arial";
    shp.TextFrame2.TextRange.Font.Size = 16;
    shp.TextFrame2.TextRange.Font.Fill.Visible = Office.MsoTriState.msoTrue;
    shp.TextFrame2.TextRange.Font.Fill.ForeColor.RGB = (int)Excel.XlRgbColor.rgbBlack;
    shp.TextFrame2.TextRange.Characters.Text = "Test";
