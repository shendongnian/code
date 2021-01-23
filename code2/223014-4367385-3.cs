    SQL = "select Bar,Store,Serial from Counter";
    dsView = new DataSet();
    using (adp = new OleDbDataAdapter(SQL, Conn)) 
        using (Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application()) {
            adp.Fill(dsView, "Counter");
            xla.Visible = false  ; 
            try {
                Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
                Worksheet ws = (Worksheet)xla.ActiveSheet;
  
                int i = 1;
  
                foreach (DataRow comp in dsView.Tables[0].Rows) {
                    ws.Cells[i, 1] = comp[0].ToString();
                    ws.Cells[i, 2] = comp[1].ToString();
                    ws.Cells[i, 3] = comp[2].ToString();
                    i++;
                }
            } finally {
                // Notice that the two following lines are totally optional as the use of 
                // using blocks assure that the used resource will necessarily be disposed
                // when getting out of the using blocks scope.
                adp.Dispose();
                xla.Dispose();
            }
    }
