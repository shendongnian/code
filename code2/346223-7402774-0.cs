    Microsoft.Office.Tools.Excel.NamedRange namedRange1 =
    this.Controls.AddNamedRange(this.Range["A1", "A5"], "namedRange1");
    namedRange1.NoteText("This is a Formatting test", missing, missing);
    namedRange1.Value2 = "Martha";
    namedRange1.Font.Name = "Verdana";
    namedRange1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
    namedRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
    namedRange1.BorderAround(missing, Excel.XlBorderWeight.xlThick,
        Excel.XlColorIndex.xlColorIndexAutomatic, missing);
    namedRange1.AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1,
        true, false, true, false, true, true);
    if (MessageBox.Show("Clear the formatting and notes?", "Test",
        MessageBoxButtons.YesNo) == DialogResult.Yes)
    {
        namedRange1.ClearFormats();
        namedRange1.ClearNotes();
    }
