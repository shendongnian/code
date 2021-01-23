    private static int GetLastRow(Worksheet worksheet)
        {
            int lastUsedRow = 1;
            Range range = worksheet.UsedRange;
            for (int i = 1; i < range.Columns.Count; i++)
            {
                int lastRow = range.Rows.Count;
                for (int j = range.Rows.Count; j > 0; j--)
                {
                    if (lastUsedRow < lastRow)
                    {
                        lastRow = j;
                        if (!String.IsNullOrWhiteSpace(Convert.ToString((worksheet.Cells[j, i] as Range).Value)))
                        {
                            if (lastUsedRow < lastRow)
                                lastUsedRow = lastRow;
                            if (lastUsedRow == range.Rows.Count)
                                return lastUsedRow - 1;
                            break;
                        }
                    }
                    else
                        break;
                }
            }
            return lastUsedRow;
        }
