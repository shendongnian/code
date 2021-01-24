                int rowCount = Rmax;
                int count = Rmax * Cmax;
                for (int row = 1; row <= Rmax; row++) {
                 bool foundValue = false;
                 int leftIndex = 1;
                 int rightIndex = Cmax;
                 for (int column = 1; column <= Cmax; column++) {
                  if (leftIndex == rightIndex) {
                   if (!foundValue) {
                    rowCount--;
                   }
                  }
                  if (!string.IsNullOrEmpty(worksheet.Cells[row, column].GetValue <String> ())) {
                   foundValue = true;
                   leftIndex++;
                  }
                  if (!string.IsNullOrEmpty(worksheet.Cells[row, column].GetValue <String> ())) {
                   foundValue = true;
                   rightIndex--;
                  }
                 }
                }
                Console.WriteLine("Number of rows" + rowCount);
