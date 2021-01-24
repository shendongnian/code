     File file = clientContext.Web.GetFileByServerRelativeUrl("/Shared%20Documents/testdata.xlsx");
                    ClientResult<System.IO.Stream> data=file.OpenBinaryStream();
                    clientContext.Load(file);
                    clientContext.ExecuteQuery();
                    using (var pck = new OfficeOpenXml.ExcelPackage())
                    {
                        //using (var stream = File.OpenRead(""))
                        //{
                        //    pck.Load(stream);
                        //}
                        using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                        {
                            if (data != null)
                            {
                                data.Value.CopyTo(mStream);
                                pck.Load(mStream);
                                var ws = pck.Workbook.Worksheets.First();
                                DataTable tbl = new DataTable();
                                bool hasHeader = true; // adjust it accordingly( i've mentioned that this is a simple approach)
                                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                                {
                                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                                }
                                var startRow = hasHeader ? 2 : 1;
                                for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                                {
                                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                                    var row = tbl.NewRow();
                                    foreach (var cell in wsRow)
                                    {
                                        if (null != cell.Hyperlink)
                                            row[cell.Start.Column - 1] = cell.Hyperlink;
                                        else
                                            row[cell.Start.Column - 1] = cell.Text;
                                    }
                                    tbl.Rows.Add(row);
                                }
                                Console.WriteLine('1');
    
                            }
                        }
                        
                        
    
                    }
