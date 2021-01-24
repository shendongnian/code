         int rowCount = Rmax;
         int count = Rmax * Cmax;
         string firstCellValue = string.Empty;
         string lastCellValue = string.Empty;
         for (int row = 1; row <= Rmax; row++) {
          bool foundValue = false;
          int leftIndex = 1;
          int rightIndex = Cmax;
          for (int column = 1; column <= Cmax; column++) {
           if (leftIndex == rightIndex) {
            if (!foundValue) {
             rowCount--;
             break;
            }
           }
           if (!string.IsNullOrEmpty(worksheet.Cells[row, column].GetValue < String > ())) {
            foundValue = true;
            firstCellValue = worksheet.Cells[row, column].ToString();
            leftIndex++;
           }
           if (!string.IsNullOrEmpty(worksheet.Cells[row, rightIndex].GetValue < String > ())) {
            foundValue = true;
            lastCellValue = worksheet.Cells[row, rightIndex].ToString();
            rightIndex--;
           }
          }
         }
         Console.WriteLine("firstCellValue" + firstCellValue);
         Console.WriteLine("lastCellValue" + lastCellValue);
         Console.WriteLine("Number of cells" + rowCount);
