    private void ThisWorkbook_Startup(object sender, System.EventArgs e)
    {
        Excel.Worksheet ws = (Excel.Worksheet)(sender as Workbook).ActiveSheet;
        
        System.Random rnd = new System.Random();
        for (int i = 1; i <= 20; i++)
            ws.Cells[i, 2] = rnd.Next(100);
    }
