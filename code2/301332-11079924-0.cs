       SaveFileDialog oDialog = new SaveFileDialog();
                        oDialog.Filter = "Excel files | *.xls";
                        if (oDialog.ShowDialog() == DialogResult.OK)
                        {
                           string  sFileName = oDialog.FileName;
                        }
                        app = new Microsoft.Office.Interop.Excel.Application();
                        workbook = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                       
                                           
                            if (sFileName != null)
                            { 
    workbook.SaveAs(sFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue,misValue, misValue, misValue, misValue);
                                workbook.Close(misValue, misValue, misValue);
                                app.Quit();
                            }
                           
                        }
    
                     for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                            {
    
                 worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText.ToUpper();
    
    
                            }
    
    
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                            {
    
                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {
    
                     worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
    
                                }
                            }
