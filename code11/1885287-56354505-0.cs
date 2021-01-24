            private void btnExport_Click(object sender, RoutedEventArgs e)
			{            
				Microsoft.Office.Interop.Excel.Application excel = null;
				Microsoft.Office.Interop.Excel.Workbook wb = null;
				object missing = Type.Missing;
				Microsoft.Office.Interop.Excel.Worksheet ws = null;
				Microsoft.Office.Interop.Excel.Range rng = null;
					
				// collection of DataGrid Items
				var dtExcelDataTable = ExcelTimeReport(txtFrmDte.Text, txtToDte.Text, strCondition);
				excel = new Microsoft.Office.Interop.Excel.Application();
				wb = excel.Workbooks.Add();
				ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
				ws.Columns.AutoFit();
				ws.Columns.EntireColumn.ColumnWidth = 25;
				// Header row
				for (int Idx = 0; Idx < dtExcelDataTable.Columns.Count; Idx++)
				{
					ws.Range["A1"].Offset[0, Idx].Value = dtExcelDataTable.Columns[Idx].ColumnName;                    
				}
				// Data Rows
				for (int Idx = 0; Idx < dtExcelDataTable.Rows.Count; Idx++)
				{  
					ws.Range["A2"].Offset[Idx].Resize[1, dtExcelDataTable.Columns.Count].Value = dtExcelDataTable.Rows[Idx].ItemArray;
				}
				excel.Visible = true;
				wb.Activate();
			}
