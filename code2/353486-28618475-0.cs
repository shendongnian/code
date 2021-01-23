    for (int h = 1; h <= 1; h++)
                    {
                        int col = lastColl(sheets);
                        for (int r = 1; r <= src.Count; r++)
                        {
                            **sheets.Cells[r, col + 1] = "'"+src.Cells[r, h].Text.ToString().Trim();**
                            dtViewImport.Rows.Add();
                            //String teste = src.Cells[r + 2, col + 1].Text;
                            //dtViewImport.Rows[r].Cells[col].Value = teste.Replace(".", ",");
                            progressBar.Value++;
                        }
                    }
