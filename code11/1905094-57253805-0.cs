    using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet namedSheet = workbook.Worksheets[0];
                    namedSheet.Range["A1"].Text = "CustomerID";
                    namedSheet.Range["B1"].Text = "CompanyName";
                    IStyle bodyStyle = workbook.Styles.Add("BodyStyle");
                    bodyStyle.BeginUpdate();
                    bodyStyle.Color = System.Drawing.Color.FromArgb(15, 19, 22);
                    bodyStyle.EndUpdate();
                    IStyle headerStyle = workbook.Styles.Add("HeaderStyle");
                    headerStyle.BeginUpdate();
                    headerStyle.Color = System.Drawing.Color.FromArgb(255, 174, 33);
                    headerStyle.EndUpdate();
                    namedSheet.Range["A10"].CellStyleName = "BodyStyle";
                    namedSheet.Range["A1"].CellStyleName = "HeaderStyle";
                    
                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms);
                    ms.Flush();
                    byte[] bytes = ms.ToArray();
                    ms.Close();
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=foo.xlsx");
                    Response.AddHeader("Content-Length", bytes.Length.ToString());
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.BinaryWrite(bytes);
                }
