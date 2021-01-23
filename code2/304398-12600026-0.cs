            try
            {
                invoice = new BLL_Invoice();
                DataTable dtAuditData = invoice.getAuditDetailsForInvoice();
                
                progressBar1.Visible = true;
                progressBar1.Minimum = 1;
                progressBar1.Maximum = dtAuditData.Rows.Count;
                progressBar1.Show();
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
                worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
                worksheet.Name = "Invoice Audit Details";
                for (int i = 1; i < dtAuditData.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dtAuditData.Columns[i-1].ColumnName;
                }
                for (int i = 0; i < dtAuditData.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dtAuditData.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dtAuditData.Rows[i][j].ToString();
                        worksheet.Cells.EntireColumn.AutoFit();
                        if (j + 1 < 17 && j + 1 > 12)
                        {
                            Excel.Range cell = (Excel.Range)worksheet.Cells[i + 2, j + 1];
                            cell.NumberFormat = "0.0000";
                            
                        }
                    }
                    progressBar1.PerformStep();
                }
                string filepath = ConfigurationManager.AppSettings["ReportLocation"].ToString();
                workbook.SaveAs(filepath+"\\AuditReport.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
                progressBar1.Hide();
                progressBar1.Visible = false;
                System.Diagnostics.Process.Start(filepath+"\\AuditReport.xls");
                progressBar1.Maximum = 0;
                progressBar1.Minimum = 0;
            }
            catch (Exception ex)
            { throw ex; }
        }
