    private DataTable GetDataTableFromExcel(String Path)
        {
            XSSFWorkbook wb;
            XSSFSheet sh;
            String Sheet_name;
            using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                wb = new XSSFWorkbook(fs);
                             
                   Sheet_name= wb.GetSheetAt(0).SheetName;  //get first sheet name
            }
            DataTable DT = new DataTable();
            DT.Rows.Clear();
            DT.Columns.Clear();
            // get sheet
            sh = (XSSFSheet)wb.GetSheet(Sheet_name);
            int i = 0;
            while (sh.GetRow(i) != null)
            {
                // add neccessary columns
                if (DT.Columns.Count < sh.GetRow(i).Cells.Count)
                {
                    for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                    {
                        DT.Columns.Add("", typeof(string));
                    }
                }
                // add row
                DT.Rows.Add();
                // write row value
                for (int j = 0; j < sh.GetRow(i).Cells.Count; j++)
                {
                    var cell = sh.GetRow(i).GetCell(j);
                    if (cell != null)
                    {
                        // TODO: you can add more cell types capatibility, e. g. formula
                        switch (cell.CellType)
                        {
                            case NPOI.SS.UserModel.CellType.Numeric:
                                DT.Rows[i][j] = sh.GetRow(i).GetCell(j).NumericCellValue;
                                //dataGridView1[j, i].Value = sh.GetRow(i).GetCell(j).NumericCellValue;
                                break;
                            case NPOI.SS.UserModel.CellType.String:
                                DT.Rows[i][j] = sh.GetRow(i).GetCell(j).StringCellValue;
                                break;
                        }
                    }
                }
                i++;
            }
            return DT;
        }
