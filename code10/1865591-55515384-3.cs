    string myHexColor = "#ffeeff";
    byte r = Convert.ToByte(myHexColor.Substring(1, 2).ToUpper(), 16);
    byte g = Convert.ToByte(myHexColor.Substring(3, 2), 16);
    byte b = Convert.ToByte(myHexColor.Substring(5, 2), 16);
    Console.WriteLine("{0} = {1}/{2}/{3}", myHexColor, r, g, b);
    IWorkbook workbook = null;
    NPOI.XSSF.UserModel.XSSFCellStyle style = (NPOI.XSSF.UserModel.XSSFCellStyle)workbook.CreateCellStyle();
    // Here we create a color from RGB-values
    IColor color = new NPOI.XSSF.UserModel.XSSFColor(new byte[] { r, g, b });
    style.SetFillForegroundColor(color );
    ICell cellToPaint = null; // Select your cell..
    cellToPaint.CellStyle = style;
