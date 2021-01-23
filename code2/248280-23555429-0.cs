    Array fieldInfoArray = new int[,] { { 1, 1 },  { 2, 1 }, { 3, 3 }, { 4, 1 } };
    ((Range)ws.Cells[1,1]).EntireColumn.TextToColumns(
    Type.Missing, Excel.XlTextParsingType.xlDelimited,
     Excel.XlTextQualifier.xlTextQualifierNone, Type.Missing,
     Type.Missing, true, Type.Missing,
     Type.Missing, Type.Missing,
     FieldInfoArray, Type.Missing,
     Type.Missing, Type.Missing);
