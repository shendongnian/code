    private void btnSearch_Click(object sender, EventArgs e)
    {
        Microsoft.Office.Interop.Excel.Application xlexcel;
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        xlexcel = new Excel.Application();
        xlexcel.Visible = true;
        //~~> Add a File
        xlWorkBook = xlexcel.Workbooks.Add();
        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        //~~> Create 2 Conditions
        xlWorkSheet.Cells[1, 1].FormatConditions.Add( 1,5,"=5");
        xlWorkSheet.Cells[1, 1].FormatConditions.Add(1, 5, "=10");
        MessageBox.Show("Wait");
        //~~> Now if you check the Excel file, Cell A1 has two conditional formats.
        //~~> See Snapshot 1
        //~~> Delete the first condition
        xlWorkSheet.Cells[1, 1].formatconditions(1).delete();
        MessageBox.Show("Wait");
        //~~> Now if you check the Excel file, Cell A1 has only 1 conditional format.
        //~~> See Snapshot 2
    }
