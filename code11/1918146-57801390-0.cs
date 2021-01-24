c#
foreach (Row row in rows) 
                {
                    bool isEmpty = false;
                    DataRow tempRow = dt.NewRow();
                    for (int i = 0; i < tempRow.ItemArray.Count(); i++)
                    {
                        if (i < row.Descendants<Cell>().Count())
                        {
                            Cell c = row.Descendants<Cell>().ElementAt(i);
                            if (c.CellValue != null)
                            {
                                tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                            }
                            else
                            {
                                if (i == 0)
                                {
                                    isEmpty = true;
                                    break;
                                }
                                else tempRow[i] = "";
                            }
                        }
                        else
                        {
                            tempRow[i] = "";
                        }
                    }
                    if (isEmpty) continue;
                    dt.Rows.Add(tempRow);
                }
