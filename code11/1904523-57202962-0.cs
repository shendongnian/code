    using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Excel2016;
                    IWorkbook workbook = application.Workbooks.Create(1);
                    IWorksheet namedSheet = workbook.Worksheets[0];
    
                    namedSheet.Range["A1"].Text = "Hey there";
                    namedSheet.Range["A2"].Text = "Good Morning";
                    namedSheet.Range["A6"].Text = "Here I am!";
                    namedSheet.Range["B5"].Text = "1";
    
                    MemoryStream ms = new MemoryStream();
                    workbook.SaveAs(ms, ",");
                    byte[] bytes = ms.ToArray();
                    ms.Flush();
                    ms.Close();
                    Response.Clear();
                    Response.AddHeader("Content-Disposition", "attachment; filename=foo.csv");
                    Response.AddHeader("Content-Length", bytes.Length.ToString());
                    Response.ContentType = "application/octet-stream";
                    Response.BinaryWrite(bytes);
                }
