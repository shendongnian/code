        private static string[,] LoadCellData(Excel.Application excel, dynamic sheet)
        {
            int countCols = CountColsToFirstBlank(excel, sheet);
            int countRows = CountRowsToFirstBlank(excel, sheet);
            cellData = new string[countCols, countRows];
            string datum;
            for (int i = 0; i < countCols; i++)
            {
                for (int j = 0; j < countRows; j++)
                {
                    try
                    {
                        if (null != sheet.Cells[i + 1, j + 1].Value)
                        {
                            datum = excel.Cells[i + 1, j + 1].Value.ToString();
                            cellData[i, j] = datum;
                        }
                    }
                    catch (Exception ex)
                    {
                        lastException = ex;
                        //Console.WriteLine(String.Format("LoadCellData [{1}, {2}] reported an error: [{0}]", ex.Message, i, j));
                    }
                }
            }
            return cellData;
        }
        private static int CountRowsToFirstBlank(Excel.Application excel, dynamic sheet)
        {
            int count = 0;
            for (int j = 0; j < sheet.UsedRange.Rows.Count; j++)
            {
                if (IsBlankRow(excel, sheet, j + 1))
                    break;
                count++;
            }
            return count;
        }
        private static int CountColsToFirstBlank(Excel.Application excel, dynamic sheet)
        {
            int count = 0;
            for (int i = 0; i < sheet.UsedRange.Columns.Count; i++)
            {
                if (IsBlankCol(excel, sheet, i + 1))
                    break;
                count++;
            }
            return count;
        }
        private static bool IsBlankCol(Excel.Application excel, dynamic sheet, int col)
        {
            for (int i = 0; i < sheet.UsedRange.Rows.Count; i++)
            {
                if (null != sheet.Cells[i + 1, col].Value)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsBlankRow(Excel.Application excel, dynamic sheet, int row)
        {
            for (int i = 0; i < sheet.UsedRange.Columns.Count; i++)
            {
                if (null != sheet.Cells[i + 1, row].Value)
                {
                    return false;
                }
            }
            return true;
        }
