	//Cells only contains references to cells with actual data
	int rowCount = worksheet.Dimension.End.Row;
	int colCount = worksheet.Dimension.End.Column;
	var cells = worksheet.Cells;
	var maxRow = cells
		.Select(c => c.Start.Row)
		.Max();
	//Go to the next row after the max
	maxRow++;
	worksheet.Cells[maxRow, 1].Value = comboBox1.Text;
	worksheet.Cells[maxRow, 2].Value = textBox1.Text;
	worksheet.Cells[maxRow, 3].Value = textBox2.Text;
	worksheet.Cells[maxRow, 4].Value = textBox3.Text;
	worksheet.Cells[maxRow, 5].Value = textBox4.Text;
	worksheet.Cells[maxRow, 6].Value = richTextBox1.Text;
