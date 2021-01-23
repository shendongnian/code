    static void Main( string[] args ) {
        string fileName = @"D:\devprj\Temp\TempProject\bin\Debug\Cartel1.xlsx";
        Application ac = new Application();
        Workbook wb = ac.Workbooks.Open( fileName );
        Worksheet ws = wb.Sheets[1];
        Range rangeOrigin = ws.get_Range( "C1" );
        Range rangeDestination = ws.get_Range( "D1" );
        rangeDestination.Value = rangeOrigin.Value2;
        wb.Save();
    }
