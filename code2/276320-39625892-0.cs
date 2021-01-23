                        for (int r = 2; r <= sheetRange.Rows.Count; r++)
                        {
                            documentRecord = new List<string>();
                            for (int c = 1; c <= wkCol; c++)
                            {
                                documentRecord.Add(sheetRange.Cells[r, c].FormulaR1C1); 
                            }
                            AllRecords.Add(documentRecord);
                        }
