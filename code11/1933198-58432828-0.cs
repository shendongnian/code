    static void Main(string[] args)
    {
        excelApp = new Excel.Application();
        excelApp.Visible = true;
        Excel.Workbook wb = excelApp.Workbooks.Add();
        Excel.Worksheet ws = (Excel.Worksheet) wb.Worksheets[1];
        var myLayout = excelApp.SmartArtLayouts[88];
        var smartArtShape = ws.Shapes.AddSmartArt(myLayout, 50, 50, 200, 200);
        if (smartArtShape.HasSmartArt == Office.MsoTriState.msoTrue)
        {
          Office.SmartArt smartArt = smartArtShape.SmartArt;
          Office.SmartArtNodes nds = smartArt.AllNodes;
        
          for (int i = 1; i <= nds.Count; i++)
          {
              nds[i].TextFrame2.TextRange.Text = "Testing " + i;
          }
        }
    }
