        static List<Excel.Range> GetCellListWithValues(Excel.Range row)
        {
            List<Excel.Range> cellList = new List<Excel.Range>();
            Excel.Range r = null;
            Excel.Range usedRow = row.Application.Intersect(row, row.Worksheet.UsedRange);
            if (usedRow != null)
            {
                foreach (Excel.Range cell in usedRow)
                    if (cell.Value2 != null)
                        cellList.Add(cell);
            }
            return cellList;
        }
