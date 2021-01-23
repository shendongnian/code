    using Microsoft.VisualBasic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using Microsoft.Office.Interop.Excel;
    public class Class1
    {
	public void TEST()
	{
		Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
		xlapp.FindFormat.Font.Name = "Arial";
		Microsoft.Office.Interop.Excel.Workbook wb = default(Microsoft.Office.Interop.Excel.Workbook);
		wb = xlapp.Workbooks.Open("C:\\test.xlsx");
		wb.Worksheets("Sheet1").Cells.Replace(What: "*", Replacement: "eee", LookAt: XlLookAt.xlWhole, SearchOrder: XlSearchOrder.xlByRows, MatchCase: false, SearchFormat: true, ReplaceFormat: false);
	}
    }
