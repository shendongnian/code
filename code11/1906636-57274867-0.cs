                                    FileInfo fi = new FileInfo(ExcelFilesPath + "myExcelFile.xlsx");
                                    using (ExcelPackage pck = new ExcelPackage())
                                    {
                                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
                                        
                                        ws.Cells["A1"].LoadFromDataTable(CustomusageMinMaxData.Tables[0], true);
                                        ws.Cells[ws.Dimension.Address].AutoFilter = true;
                                        Color colFromHex = System.Drawing.ColorTranslator.FromHtml("#00B388");
                                        ws.Cells[ws.Dimension.Address].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        ws.Cells[ws.Dimension.Address].Style.Fill.BackgroundColor.SetColor(colFromHex);
                                        ws.Cells[ws.Dimension.Address].Style.Font.Color.SetColor(Color.White);
                                        ws.Cells[ws.Dimension.Address].Style.Font.Bold = true;
                                        ws.Cells["D:K"].Style.Numberformat.Format = "0";
                                        ws.Cells["M:N"].Style.Numberformat.Format = "mm-dd-yyyy hh:mm:ss";
                                        ws.Cells[ws.Dimension.Address].AutoFitColumns();
                                        
                                        pck.SaveAs(fi);
                                        
                                        
                                    }
