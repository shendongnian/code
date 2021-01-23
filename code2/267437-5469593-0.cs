     OpenExcelWorkbook(OldFilePath);
                    _sheet = (Excel.Worksheet)_sheets[1];
                    _sheet.Select(Type.Missing);
                    var oldData = new DataTable();
                    oldData.Columns.Add("Id", typeof(string));
                    oldData.Columns.Add("Comment1", typeof(string));
                    oldData.Columns.Add("Comment2", typeof(string));
                    oldData.Columns.Add("Comment3", typeof(string));
                    var range = _sheet.UsedRange;
                    for (var i = 1; i <= range.Rows.Count; i++)
                    {
                        var id = "";
                        var comment1 = "";
                        var comment2 = "";
                        var comment3 = "";
                        if (((Excel.Range)_sheet.Cells[i, 1]).Value2 != null)
                            id = ((Excel.Range)_sheet.Cells[i, 1]).Value2.ToString();
                        if (((Excel.Range)_sheet.Cells[i, 10]).Value2 != null)
                            comment1 = ((Excel.Range)_sheet.Cells[i, 10]).Value2.ToString();
                        if (((Excel.Range)_sheet.Cells[i, 11]).Value2 != null)
                            comment2 = ((Excel.Range)_sheet.Cells[i, 11]).Value2.ToString();
                        if (((Excel.Range)_sheet.Cells[i, 12]).Value2 != null)
                            comment3 = ((Excel.Range)_sheet.Cells[i, 12]).Value2.ToString();
                        if (comment1 != "" || comment2 != "" || comment3 != "")
                            oldData.Rows.Add(id, comment1, comment2, comment3);
                    }
                    _book.Save();
                    _book.Close(false, Type.Missing, Type.Missing);
                    _app.Quit();
                    releaseObject(_sheet);
                    releaseObject(_book);
                    releaseObject(_app);
                    OpenExcelWorkbook(NewFilePath);
                    _sheet = (Excel.Worksheet)_sheets[1];
                    _sheet.Select(Type.Missing);
                    range = _sheet.Range["D:E", Type.Missing];
                    range.EntireColumn.Delete(Type.Missing);
                    range = _sheet.Range["E:F", Type.Missing];
                    range.EntireColumn.Delete(Type.Missing);
                    range = _sheet.Range["F:I", Type.Missing];
                    range.EntireColumn.Delete(Type.Missing);
                    _sheet.Cells[4, 3] = "Invoice";
                    _sheet.Cells[4, 4] = "Transaction";
                    _sheet.Cells[4, 5] = "Receipt";
                    range = _sheet.UsedRange;
                    var convDataTable = new DataTable();
                    convDataTable.Columns.Add("Id", typeof(string));
                    convDataTable.Columns.Add("Comment1", typeof(string));
                    convDataTable.Columns.Add("Comment2", typeof(string));
                    convDataTable.Columns.Add("Comment3", typeof(string));
                    for (var i = 1; i < range.Rows.Count; i++)
                    {
                        var id = "";
                        if (((Excel.Range)_sheet.Cells[i, 1]).Value2 != null)
                            id = ((Excel.Range)_sheet.Cells[i, 1]).Value2.ToString();
                        convDataTable.Rows.Add(id, "", "", "");
                    }
                    foreach (DataRow row in convDataTable.Rows)
                    {
                        foreach (DataRow row1 in oldData.Rows)
                        {
                            var oldId = row1[0].ToString();
                            var newId = row[0].ToString();
                            if (newId != "")
                            {
                                if (newId == oldId)
                                {
                                    var comment1 = row1[1].ToString();
                                    var comment2 = row1[2].ToString();
                                    var comment3 = row1[3].ToString();
                                    row[1] = comment1;
                                    row[2] = comment2;
                                    row[3] = comment3;
                                    break;
                                }
                            }
                        }
                    }
                    for (var i = 1; i <= convDataTable.Rows.Count; i++)
                    {
                        _app.Cells[i, 10] = convDataTable.Rows[i - 1]["Comment1"].ToString();
                        _app.Cells[i, 11] = convDataTable.Rows[i - 1]["Comment2"].ToString();
                        _app.Cells[i, 12] = convDataTable.Rows[i - 1]["Comment3"].ToString();
                    }
                    _book.Save();
                    _book.Close(false, Type.Missing, Type.Missing);
                    _app.Quit();
                    releaseObject(_sheet);
                    releaseObject(_book);
                    releaseObject(_app);
                    MessageBox.Show("The converting is finished");
