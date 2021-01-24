var excelDate = excelApp.WorksheetFunction.VLookup(input, sheetToLook.Range["A2:G4"], 3, false);
if(excelDate is double oaDate)
{
    dateLabel.Text = DateTime.FromOADate(oaDate);
}
