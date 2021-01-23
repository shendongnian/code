    Microsoft.Office.Interop.Excel.Range range = gXlWs.get_Range("A1", "F188000");
    object[,] values = (object[,])range.Value2;
    int NumRow=1;
    while (NumRow < values.GetLength(0))
    {
        for (int c = 1; c <= NumCols; c++)
        {
            Fields[c - 1] = Convert.ToString(values[NumRow, c]);
        }
        NumRow++;
    }
