    public static void GenerateExcel(List<Users> users, string _path)
    {
	    using (ExcelPackage exPackage = new ExcelPackage())
	    {
		    ExcelWorksheet ws = exPackage.Workbook.Worksheets.Add(Path.GetFileNameWithoutExtension(_path));
		    ws.Cells.Style.Font.SetFromFont(new Font("Calibri", 10));
		    ws.Cells.AutoFitColumns();
		    ExcelRange aHeaderRange = ws.Cells["A1:E1"];
		    aHeaderRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
		    aHeaderRange.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
		    short rNo = 1;
		    ws.Cells[rNo, 1].Value = "Customer No";
		    ws.Cells[rNo, 2].Value = "Name";
		    ws.Cells[rNo, 3].Value = "DoB";
		    ws.Cells[rNo, 4].Value = "Designation";
		    ws.Cells[rNo, 5].Value = "Address";
		    rNo = 2;
		    foreach (var m in users)
		    {
			    ws.Cells[rNo, 1].Value = m.CustNo;
			    ws.Cells[rNo, 2].Value = m.Name;
			    ws.Cells[rNo, 3].Value = m.DoB;
			    ws.Cells[rNo, 4].Value = m.Designation;
			    ws.Cells[rNo, 5].Value = m.Address;
			    rNo++;
		    }
    		FileInfo excelFile = new FileInfo(_path);
		    exPackage.SaveAs(excelFile);
	    }
    }
    public class Users
    {
	    public string CustNo { get; set; }
	    public string Name { get; set; }
	    public string DoB { get; set; }
	    public string Designation { get; set; }
	    public string Address { get; set; }
    }
