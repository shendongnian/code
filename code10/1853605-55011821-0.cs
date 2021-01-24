        static Excel.Range GetCellsWithValues(Excel.Range row)
        {
            Excel.Range r = null;
            // Cut out unneccessary calcs by using only the intersection of the Row with the UsedRange
            Excel.Range usedRow = row.Application.Intersect(row, row.Worksheet.UsedRange);
            if (usedRow != null)
            {
                foreach (Excel.Range cell in usedRow)
                    if (cell.Value2 != null)  //if non-empty unite to r
                        r = (r == null) ? cell : row.Application.Union(r, cell);
            }
            return r;  // a non-contiguous Range will have Areas with blocks of contiguous Ranges
        }
        static List<Excel.Range> GetCellListFromAreas(Excel.Range r)
        {   // this will unwrap the cells from non-contiguous range into a List
            // choose other collections for your use
            List<Excel.Range> cellList = new List<Excel.Range>();
            Excel.Areas areas = r?.Areas;
            if (areas != null)
            { 
                // Unwrap the Areas (blocks of contiguous cells)
                foreach (Excel.Range area in areas)
                    foreach (Excel.Range cell in area)
                        cellList.Add(cell);  // add each cell in each contiguous block
            }
            return cellList;
        }
