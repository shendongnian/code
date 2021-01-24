// Create Excel instance
Excel.Application excel = new Excel.Application { Visible = true };
Excel.Workbook book = excel.Workbooks.Open(@"PATH_TO_FILE");
Excel.Worksheet sheet = book.Sheets[1] as Excel.Worksheet;
// Search in the first row
Excel.Range header = sheet.Range["1:1"].Find("AMT_ISSUED", LookAt: Excel.XlLookAt.xlWhole);
if (header != null)
{
    // Header is found
    int index = header.Column;
}
else
{
    // Header is not found
}
