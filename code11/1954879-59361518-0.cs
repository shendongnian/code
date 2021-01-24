    public static DataTable LoadFromStreamExcel(String _path, bool _has_header)
    {
    	DataTable _datatable = new DataTable();
    	var fileinfo = new FileInfo(_path);
    	using (ExcelPackage pack = new ExcelPackage(fileinfo))
    	{
    		ExcelWorksheet ws = pack.Workbook.Worksheets.First();
    		foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
    		{
    			_datatable.Columns.Add(_has_header ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
    		}
    		var startRow = _has_header ? 2 : 1;
    		for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
    		{
    			var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
    			DataRow row = _datatable.Rows.Add();
    			foreach (var cell in wsRow)
    			{
    				row[cell.Start.Column - 1] = cell.Value;
    			}
    		}
    	}
    	return _datatable;
    }
