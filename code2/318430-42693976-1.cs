	// creating Excel Application
	Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
	// creating new WorkBook within Excel application
	Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
	// creating new Excelsheet in workbook
	Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
	// see the excel sheet behind the program
	app.Visible = true;
	// get the reference of first sheet. By default its name is Sheet1.
	// store its reference to worksheet
	worksheet = workbook.Sheets["Sheet1"];
	worksheet = workbook.ActiveSheet;
	// changing the name of active sheet
	worksheet.Name = "Exported from gridview";
	try
	{
		// storing header part in Excel
		for (int i = 1; i < dgvRESULTS.Columns.Count + 1; i++)
		{
			worksheet.Cells[1, i] = dgvRESULTS.Columns[i - 1].HeaderText;
			worksheet.Cells[1, i].Interior.Color = System.Drawing.Color.LightYellow;
		}
		// storing Each row and column value to excel sheet
		for (int i = 0; i < dgvRESULTS.Rows.Count - 1; i++)
		{
			for (int j = 0; j < dgvRESULTS.Columns.Count; j++)
			{
				if (dgvRESULTS.Rows[i].Cells[j].Value != null)
				{
					worksheet.Cells[i + 2, j + 1] = dgvRESULTS.Rows[i].Cells[j].Value.ToString();
					//worksheet.Cells[i + 2, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(dgvRESULTS.Rows[i].DefaultCellStyle.BackColor);
				}
				else
				{
					worksheet.Cells[i + 2, j + 1] = "";
				}
			}
		}
	}
	catch(NullReferenceException ne)
	{
	}
	string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	// save the application
	workbook.SaveAs(filePath +"\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
	// Exit from the application
	app.Quit();
