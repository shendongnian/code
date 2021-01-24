    	IStyle style = workbook.Styles.Add("style1");
		style.BeginUpdate();
		style.FillPattern = ExcelPattern.Gradient;
		style.Interior.Gradient.GradientStyle = ExcelGradientStyle.Vertical;
		style.Interior.Gradient.BackColor = Color.Black;
		style.Interior.Gradient.ForeColor = Color.Beige;
        //Apply style to range of cells
		namedSheet.Range["A10"].CellStyleName = "style1";
		style.EndUpdate();
		workbook.SaveAs(@"c:\temp\test.xlsx");
		workbook.Close();
		excelEngine.Dispose();
