    for (int F = 0; F < (21*SECT); F++)
    {
         Console.WriteLine(AllY[F]);   // Shows the byte array mentioned.
         MyYData[F] = AllY[F].ToString();  // The data is sotred as succesions of strings.
    }
    Console.ReadKey();
                
    Excel.Application excelApp = new Excel.Application();
    excelApp.Visible = true;
    string myPath = @"C:\Documents and Settings\John\My Documents\DATA.xls";   // The main downside to this code, is that the document must exist prior to code execution (but i'm sure you guys can figure out a way for the code to create de document).
    excelApp.Workbooks.Open(myPath);                                                            
    for (int r = 1; r < ((21 * SECT)+1); r++)  // r must be set to 1, because cell 0x0 doesn't exist!
    {
         int rowIndex = r;
         int colIndex = 1;
         excelApp.Cells[rowIndex, colIndex] = MyYData[r-1];
         excelApp.Visible = true;
    }
    Console.ReadKey();
