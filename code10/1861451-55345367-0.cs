    for (int i = 0; i < listBox3.Items.Count; i++)
    {
        worksheet.Cells[i + 21, 1] = listBox3.Items[i].ToString();
        worksheet.Cells[i + 21, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
    }
