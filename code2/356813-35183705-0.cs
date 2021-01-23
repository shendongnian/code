    int GetLastRow(Worksheet worksheet)
            {
                int lastUsedRow = 1;
                Range range = worksheet.UsedRange;
                int lastRow = range.Rows.Count;
                for (int i = 1; i < range.Columns.Count; i++)
                {
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
                                    return lastUsedRow;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
                return lastUsedRow;
            }
