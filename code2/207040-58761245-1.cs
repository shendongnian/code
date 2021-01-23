            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(1);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            // changing the name of active sheet
            ws.Name = "Exported from gridview";
            ws.Rows.HorizontalAlignment = HorizontalAlignment.Center;
            app.ActiveWindow.Activate();
          
            ws.Activate();
            ws.Paste();
            ws.Cells.EntireColumn.AutoFit();
