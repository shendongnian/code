    DataSet ds = new DataSet();
                DataTable dt = ds.Tables[0];
                using (ExcelPackage pck = new ExcelPackage())
                {
                    //Create the worksheet
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Calls");
                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    
                    Byte[] bin = pck.GetAsByteArray();
                    string file = filePath;
                    File.WriteAllBytes(file, bin);
                }
