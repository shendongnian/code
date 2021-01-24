            for (int i = rowCount - 1; i >= 0; i--)
            {
                 if (usedRange.Cells[i, 1] == null)
                 {
                    // Delete entire row if first cell is empty
                    usedRange.Cells[i, 1]).EntireRow.Delete(null);
                 }
            }
            workbook.Save();
