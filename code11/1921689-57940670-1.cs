    foreach (var row in sheet.Rows)
    {
         int i = 0;
         float avg = 0;
         foreach (var cell in row.Cells)
         {
                 i += 1;
                 if (i > colAverage) {
                 float grade = cell.value;
                 avg += grade;
                 }
         }
         row[colAverage] = avg / (row.Cells.Count - colAverage);
    }
