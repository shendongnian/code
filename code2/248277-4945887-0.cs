    ((Range)ws.Cells[1,1]).EntireColumn.TextToColumns(
    Type.Missing, Excel.XlTextParsingType.xlDelimited,
     Excel.XlTextQualifier.xlTextQualifierNone, Type.Missing,
     Type.Missing, true, Type.Missing,
     Type.Missing, Type.Missing,
     Type.Missing,
     int[][] fieldInfoArray = { new int[] { 1, 1 }, new int[] { 2, 4 }, new int[] { 3, 7 }, new int[] { 4, 1 } };,
     Type.Missing, Type.Missing);
